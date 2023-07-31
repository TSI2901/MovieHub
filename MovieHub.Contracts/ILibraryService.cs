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
        Task<AddMovieViewModel> GetNewAddMovieModelAsync();
        Task<AddDirectorViewModel> GetNewAddDirectorModelAsync();
        Task<AddActorViewModel> GetNewAddActorModelAsync();
        Task<MovieDetails?> GetMovieByIdAsync(Guid id);
        Task<ActorDetails?> GetActorByIdAsync(Guid id);
        Task<DirectorDetails?> GetDirectorByIdAsync(Guid id);

         //Task<AddMovieViewModel> GetNewAddMovieModelAsync();
         //Task<AddMovieViewModel> GetNewAddMovieModelAsync();
    }
}
