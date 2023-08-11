using Microsoft.EntityFrameworkCore;
using MovieHub.Contracts;
using MovieHub.Data;
using MovieHub.Data.Models;
using MovieHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Services
{
    public class MovieService:IMovieService
    {
        private readonly MovieHubDbContext db;

        public MovieService(MovieHubDbContext context)
        {
            db = context;
        }

        public async Task<AddMovieViewModel> GetNewAddMovieModelAsync()
        {
            var categories = await db.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            var rewads = await db.Rewards.Select(x => new RewardViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();

            var model = new AddMovieViewModel()
            {
                Categories = categories,
                Rewards = rewads
            };
            return model;
        }
        public async Task<MovieDetailsViewModel?> GetMovieByIdAsync(Guid id)
        {
            var searchedMovie = await db.Movies.FirstAsync(x => x.Id == id);
            var movie = await db.Movies.Where(x => x.Id == id).Select(x => new MovieDetailsViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ReleaseDate = x.ReleaseDate,
                ImgURL = x.ImgURL,
                Budget = x.Budget,
                MovieActors = x.MovieActors,
                Comments = x.Comments,
                MovieDirectors = x.MovieDirectors,

                MovieLength = x.MovieLength,
                Categories = x.Categories,
                MovieLikes = x.MovieLikes
            }).FirstOrDefaultAsync();
            foreach (var item in movie.Categories)
            {
                item.Movie = await db.Movies.FirstOrDefaultAsync(x => x.Id == item.MovieId);
                item.Category = await db.Categories.FirstOrDefaultAsync(x => x.Id == item.CategoryId);
            }

            foreach (var item in movie.MovieActors)
            {
                item.Actor = await db.Actors.FirstOrDefaultAsync(x => x.Id == item.ActorId);
            }
            foreach (var item in movie.MovieDirectors)
            {
                item.Director = await db.Directors.FirstOrDefaultAsync(x => x.Id == item.DirectorId);
            }
            return movie;
        }
        public async Task<string> LikeMovieAsync(Guid movieId, string followerId)
        {
            bool alreadyAdded = await db.MovieLikes.AnyAsync(x => x.FollowerId == followerId && x.MovieId == movieId);
            if (!alreadyAdded)
            {
                var eventParticipant = new MovieLike()
                {
                    FollowerId = followerId,
                    MovieId = movieId
                };
                await db.MovieLikes.AddAsync(eventParticipant);
                await db.SaveChangesAsync();
                return "Done";
            }
            return "already Added";
        }

        public async Task RemoveLikeMovieAsync(Guid movieId, string followerId)
        {
            bool isHere = await db.MovieLikes.AnyAsync(x => x.FollowerId == followerId && x.MovieId == movieId);
            if (isHere)
            {
                var eventParticipant = await db.MovieLikes.FirstAsync(x => x.FollowerId == followerId && x.MovieId == movieId);
                db.MovieLikes.Remove(eventParticipant);
                await db.SaveChangesAsync();
            }
        }
        public async Task AddMovieAsync(AddMovieViewModel movieView)
        {
            var searchStudio = db.Studios.FirstOrDefault(x => x.Name == movieView.StudioName);
            if (searchStudio == null)
            {
                searchStudio = new Studio()
                {
                    Id = Guid.NewGuid(),
                    Name = movieView.StudioName
                };
                await db.Studios.AddAsync(searchStudio);
            }

            var movie = new Movie()
            {
                Id = Guid.NewGuid(),
                Title = movieView.Title,
                Description = movieView.Description,
                ReleaseDate = movieView.ReleaseDate,
                MovieLength = movieView.MovieLength,
                ImgURL = movieView.ImgURL,
                Budget = movieView.Budget,
                MovieStudio = searchStudio,
                StudioId = searchStudio.Id
            };
            var categories = new HashSet<CategoryViewModel>
            {
                movieView.FirstCategorieId, movieView.SecondCategorieId, movieView.ThirdCategorieId
            };
            var rewards = new HashSet<RewardViewModel>
            {
                movieView.FirstReward,movieView.SecondReward, movieView.ThirdReward
            };
            var listMovieCategories = new List<MovieCategory>();

            foreach (var cat in categories)
            {
                if (cat != null)
                {
                    if (!movie.Categories.Any(x => x.CategoryId == cat.Id))
                    {
                        var category = await db.Categories.FirstAsync(x => x.Id == cat.Id);
                        MovieCategory movieCategory = new MovieCategory
                        {
                            Movie = movie,
                            MovieId = movie.Id,
                            Category = category,
                            CategoryId = cat.Id
                        };
                        movie.Categories.Add(movieCategory);
                        category.Movies.Add(movieCategory);
                        listMovieCategories.Add(movieCategory);
                    }


                }
            }
            foreach (var reward in rewards)
            {
                if (reward != null)
                {

                    movie.Rewards.Add(await db.Rewards.FirstAsync(x => x.Id == reward.Id));
                }
            }
            await db.Movies.AddAsync(movie);
            await db.MoviesCategories.AddRangeAsync(listMovieCategories);
            await db.SaveChangesAsync();
        }
        public async Task<AddMovieViewModel?> GetMovieByIdForEditAsync(Guid Id)
        {
            var categories = await db.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            var rewads = await db.Rewards.Select(x => new RewardViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();

            return await db.Movies.Where(x => x.Id == Id).Select(x => new AddMovieViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ReleaseDate = x.ReleaseDate,
                Categories = categories,
                Rewards = rewads,
                ImgURL = x.ImgURL,
                StudioName = x.MovieStudio.Name,
                Budget = x.Budget,
                MovieLength = x.MovieLength,


            }).FirstOrDefaultAsync();
        }

        public async Task EditMovieAsync(AddMovieViewModel model)
        {
            var currMovie = await db.Movies.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (currMovie == null)
            {
                return;
            }
            var searchStudio = db.Studios.FirstOrDefault(x => x.Name == model.StudioName);
            if (searchStudio == null)
            {
                searchStudio = new Studio()
                {
                    Id = Guid.NewGuid(),
                    Name = model.StudioName
                };
                await db.Studios.AddAsync(searchStudio);
            }
            currMovie.Title = model.Title;
            currMovie.Description = model.Description;
            currMovie.Budget = model.Budget;
            currMovie.MovieStudio = searchStudio;
            currMovie.StudioId = searchStudio.Id;
            currMovie.ImgURL = model.ImgURL;
            currMovie.MovieLength = model.MovieLength;
            var categories = new HashSet<CategoryViewModel>
            {
                model.FirstCategorieId, model.SecondCategorieId, model.ThirdCategorieId
            };
            var rewards = new HashSet<RewardViewModel>
            {
                model.FirstReward,model.SecondReward, model.ThirdReward
            };
            var listMovieCategories = new List<MovieCategory>();
            var listToRemove = await db.MoviesCategories.Where(x => x.MovieId == currMovie.Id).ToListAsync();
            db.MoviesCategories.RemoveRange(listToRemove);
            currMovie.Categories.Clear();
            currMovie.Rewards.Clear();
            foreach (var cat in categories)
            {
                if (cat != null)
                {
                    if (!currMovie.Categories.Any(x => x.CategoryId == cat.Id))
                    {
                        var category = await db.Categories.FirstAsync(x => x.Id == cat.Id);

                        MovieCategory movieCategory = new MovieCategory
                        {
                            Movie = currMovie,
                            MovieId = currMovie.Id,
                            Category = category,
                            CategoryId = cat.Id
                        };
                        if (!await db.MoviesCategories.AllAsync(x => x.MovieId == currMovie.Id && x.CategoryId == category.Id))
                        {
                            currMovie.Categories.Add(movieCategory);
                            category.Movies.Add(movieCategory);
                            listMovieCategories.Add(movieCategory);
                        }
                        else
                        {
                            currMovie.Categories.Add(await db.MoviesCategories.FirstAsync(x => x.CategoryId == category.Id && x.MovieId == currMovie.Id));
                        }

                    }
                }
            }
            foreach (var reward in rewards)
            {
                if (reward != null)
                {

                    currMovie.Rewards.Add(await db.Rewards.FirstAsync(x => x.Id == reward.Id));
                }
            }
            if (listMovieCategories.Any())
            {
                await db.MoviesCategories.AddRangeAsync(listMovieCategories);
            }
            await db.SaveChangesAsync();
        }
        public async Task DeleteMovieAsync(Guid movieId)
        {
            var movie = await db.Movies.Include(x => x.Rewards).FirstOrDefaultAsync(x => x.Id == movieId);
            var movieCategoties = await db.MoviesCategories.Where(x => x.MovieId == movieId).ToListAsync();
            var movieActors = await db.MoviesActors.Where(x => x.MovieId == movieId).ToListAsync();
            var movieDirectors = await db.MoviesDirectors.Where(x => x.MovieId == movieId).ToListAsync();
            movie.Rewards.Clear();
            if (movie != null)
            {
                db.MoviesActors.RemoveRange(movieActors);
                db.MoviesCategories.RemoveRange(movieCategoties);
                db.MoviesDirectors.RemoveRange(movieDirectors);
                db.Movies.Remove(movie);
            }
            await db.SaveChangesAsync();
        }

    }
}
