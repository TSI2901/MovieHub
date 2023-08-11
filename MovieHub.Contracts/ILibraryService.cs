using MovieHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Contracts
{
    public interface ILibraryService
    {
        Task<IEnumerable<AllMoviesViewModel>> GetAllMovies();
       
        Task<IEnumerable<AllMoviesViewModel>> GetLikedMovies(string userId);
        Task AddCommentAsync(Guid movieId, string comment, string authorId);
        Task RemoveComment(Guid movieId, Guid commentId);
        Task EditComment(Guid commnetId);
        //Task<MovieDetailsViewModel?> GetMovieById(Guid id);

        
        
    }
}
