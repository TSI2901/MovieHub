using Microsoft.EntityFrameworkCore;
using MovieHub.Contracts;
using MovieHub.Data;
using MovieHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly MovieHubDbContext db;

        public LibraryService(MovieHubDbContext context)
        {
            db = context;
        }
        public async Task<IEnumerable<AllMoviesViewModel>> GetAllMovies()
        {
            return await db.Movies.Select(x => new AllMoviesViewModel
            {
                Id = x.Id,
                Name = x.Title,
                ImgURL = x.ImgURL,
                CreatedOn = x.ReleaseDate,
                Categories = x.Categories.Select(x => x.Category.Name).ToHashSet(),
                MovieLength = x.MovieLength
            }).ToListAsync();
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
        public async Task<AddActorViewModel> GetNewAddActorModelAsync()
        {
            var rewads = await db.Rewards.Select(x => new RewardViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();

            var model = new AddActorViewModel()
            {
                Rewards = rewads
            };
            return model;
        }

        public async Task<MovieDetailsViewModel?> GetMovieByIdAsync(Guid id)
        {
            return await db.Movies.Where(x => x.Id == id).Select(x => new MovieDetailsViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ReleaseDate = x.ReleaseDate,
                DirectorId = x.DirectorId,
                ImgURL = x.ImgURL,
                Budget = x.Budget,
                MovieActors = x.MovieActors,
                Comments = x.Comments,
                MovieDirectors = x.MovieDirectors,
                Rewards = x.Rewards,
                Categories = x.Categories,
                MovieLikes = x.MovieLikes
            }).FirstOrDefaultAsync();
        }

        public async Task<ActorDetailsViewModel?> GetActorByIdAsync(Guid id)
        {
            return await db.Actors.Where(x => x.Id == id).Select(x => new ActorDetailsViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ImgURL= x.ImgURL,
                BornDate = x.BornDate,
                Description = x.Description,
                BornCityName = x.BornCityName,
                Rewards = x.Rewards,
                Movies = x.Movies
            }).FirstOrDefaultAsync();
        }

        public async Task<DirectorDetailsViewModel?> GetDirectorByIdAsync(Guid id)
        {
            return await db.Directors.Where(x => x.Id == id).Select(x => new DirectorDetailsViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ImgURL = x.ImgURL,
                BornDate = x.BornDate,
                Description = x.Description,
                BornCityName = x.BornCityName,
                Rewards = x.Rewards,
                Movies = x.Movies
            }).FirstOrDefaultAsync();
        }
    }
}
