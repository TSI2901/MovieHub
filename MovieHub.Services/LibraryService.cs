using Microsoft.EntityFrameworkCore;
using MovieHub.Contracts;
using MovieHub.Data;
using MovieHub.Data.Models;
using MovieHub.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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

       

        public async Task<IEnumerable<AllMoviesViewModel>> GetLikedMovies(string userId)
        {
            return await db.MovieLikes.Where(x => x.FollowerId == userId).Select(x => new AllMoviesViewModel
            {
                Id = x.MovieId,
                Name = x.Movie.Title,
                ImgURL = x.Movie.ImgURL,
                CreatedOn = x.Movie.ReleaseDate,
                Categories = x.Movie.Categories.Select(x => x.Category.Name).ToList(),
                MovieLength = x.Movie.MovieLength
            }).ToListAsync();
        }

        public async Task AddCommentAsync(Guid movieId, string comment, string authorId)
        {
            var com = new Comment
            {
                Id = Guid.NewGuid(),
                CommentEssence = comment,
                AuthorId = authorId,
                MovieId = movieId
            };
            var movie = await db.Movies.FirstOrDefaultAsync(x => x.Id == movieId);
            if (movie != null)
            {
                movie.Comments.Add(com);
                await db.Comments.AddAsync(com);
                await db.SaveChangesAsync();
            }
        }

        public async Task RemoveComment(Guid movieId, Guid commentId)
        {
            var com = await db.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
            var movie = await db.Movies.FirstOrDefaultAsync(x => x.Id == movieId);

            if (movie != null && com != null)
            {
                movie.Comments.Remove(com);
                db.Comments.Remove(com);
                await db.SaveChangesAsync();
            }
            
        }

        public Task EditComment(Guid commnetId)
        {
            throw new NotImplementedException();
        }

       

       
     

        
    }
    
    
}
