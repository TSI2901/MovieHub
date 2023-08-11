using MovieHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Contracts
{
    public interface IMovieService
    {
        Task<AddMovieViewModel> GetNewAddMovieModelAsync();
        Task<MovieDetailsViewModel?> GetMovieByIdAsync(Guid id);
        Task<string> LikeMovieAsync(Guid movieId, string followerId);
        Task RemoveLikeMovieAsync(Guid movieId, string followerId);
        Task AddMovieAsync(AddMovieViewModel movie);
        Task DeleteMovieAsync(Guid movieId);
        Task<AddMovieViewModel?> GetMovieByIdForEditAsync(Guid Id);
        Task EditMovieAsync(AddMovieViewModel model);
    }
}
