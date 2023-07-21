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
    }
}
