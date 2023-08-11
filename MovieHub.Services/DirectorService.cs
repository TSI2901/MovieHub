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
    public class DirectorService:IDirectorService
    {
        private readonly MovieHubDbContext db;

        public DirectorService(MovieHubDbContext context)
        {
            db = context;
        }

        public async Task<AddDirectorViewModel> GetNewAddDirectorModelAsync()
        {
            var rewads = await db.Rewards.Select(x => new RewardViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();

            var model = new AddDirectorViewModel()
            {
                Rewards = rewads
            };
            return model;
        }
        public async Task<DirectorDetailsViewModel?> GetDirectorByIdAsync(Guid id)
        {
            var searchedDirector = await db.Directors.FirstAsync(x => x.Id == id);
            var director = await db.Directors.Where(x => x.Id == id).Select(x => new DirectorDetailsViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ImgURL = x.ImgURL,
                BornDate = x.BornDate,
                Description = x.Description,
                BornCityName = x.BornCityName,

                Movies = x.Movies
            }).FirstOrDefaultAsync();
            foreach (var item in searchedDirector.Rewards)
            {
                director.Rewards.Add(item);
            }
            foreach (var item in director.Movies)
            {
                item.Movie = await db.Movies.FirstOrDefaultAsync(x => x.Id == item.MovieId);
            }
            return director;
        }
        public async Task AddDirectorAsync(AddDirectorViewModel director, Guid movieId)
        {
            bool IsExist = await db.Directors.AnyAsync(x => x.FirstName == director.FirstName && x.LastName == director.LastName && x.Description == director.Description);
            Movie movieToAdd = await db.Movies.FirstAsync(x => x.Id == movieId);
            var rewards = new List<RewardViewModel>
            {
                director.FirstReward,director.SecondReward, director.ThirdReward
            };
            var movieDirector = new MovieDirector
            {
                MovieId = movieId,
                Movie = movieToAdd,

            };
            if (!IsExist)
            {
                var directorCreate = new Director
                {
                    Id = Guid.NewGuid(),
                    FirstName = director.FirstName,
                    LastName = director.LastName,
                    BornCityName = director.BornCityName,
                    Description = director.Description,
                    BornDate = director.BornDate,
                    DeathDate = director.DeathDate,
                    ImgURL = director.ImgURL

                };
                for (int i = 0; i < rewards.Count; i++)
                {
                    if (rewards[i] != null)
                    {

                        directorCreate.Rewards.Add(await db.Rewards.FirstAsync(x => x.Id == rewards[i].Id));
                    }
                }
                movieDirector.Director = directorCreate;
                movieDirector.DirectorId = directorCreate.Id;
                directorCreate.Movies.Add(movieDirector);
                await db.Directors.AddAsync(directorCreate);
            }
            else
            {
                Director findDirector = await db.Directors.FirstAsync(x => x.FirstName == director.FirstName && x.LastName == director.LastName && x.Description == director.Description);
                movieDirector.Director = findDirector;
                movieDirector.DirectorId = findDirector.Id;
                findDirector.Movies.Add(movieDirector);
            }
            movieToAdd.MovieDirectors.Add(movieDirector);

            await db.MoviesDirectors.AddAsync(movieDirector);
            await db.SaveChangesAsync();
        }
        public async Task EditDirectorAsync(AddDirectorViewModel model)
        {
            var currDirector = await db.Directors.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (currDirector == null)
            {
                return;
            }
            var rewards = new HashSet<RewardViewModel>
            {
                model.FirstReward,model.SecondReward, model.ThirdReward
            };

            currDirector.FirstName = model.FirstName;
            currDirector.LastName = model.LastName;
            currDirector.Description = model.Description;
            currDirector.BornDate = model.BornDate;
            currDirector.DeathDate = model.DeathDate;
            currDirector.BornCityName = model.BornCityName;
            currDirector.ImgURL = model.ImgURL;

            currDirector.Rewards.Clear();
            foreach (var reward in rewards)
            {
                if (reward != null)
                {
                    var crA = await db.Rewards.FirstAsync(x => x.Id == reward.Id);
                    currDirector.Rewards.Add(await db.Rewards.FirstAsync(x => x.Id == reward.Id));
                }
            }

            await db.SaveChangesAsync();
        }
        public async Task DeleteDirectorAsync(Guid directorId)
        {
            var director = await db.Directors.Include(x => x.Rewards).FirstOrDefaultAsync(x => x.Id == directorId);

            var movieActors = await db.MoviesDirectors.Where(x => x.DirectorId == directorId).ToListAsync();
            director.Rewards.Clear();
            if (director != null)
            {
                db.MoviesDirectors.RemoveRange(movieActors);

                db.Directors.Remove(director);
            }
            await db.SaveChangesAsync();
        }

        public async Task<AddDirectorViewModel?> GetDirectorByIdForEditAsync(Guid Id)
        {
            var rewads = await db.Rewards.Select(x => new RewardViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();

            return await db.Directors.Where(x => x.Id == Id).Select(x => new AddDirectorViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Description = x.Description,
                Rewards = rewads,
                BornDate = x.BornDate,
                ImgURL = x.ImgURL,
                DeathDate = x.DeathDate,
                BornCityName = x.BornCityName
            }).FirstOrDefaultAsync();
        }
    }
}
