using MovieHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Contracts
{
    public interface IDirectorService
    {
        Task EditDirectorAsync(AddDirectorViewModel model);
        Task<AddDirectorViewModel?> GetDirectorByIdForEditAsync(Guid Id);
        Task AddDirectorAsync(AddDirectorViewModel director, Guid movieId);
        Task DeleteDirectorAsync(Guid directorId);
        Task<DirectorDetailsViewModel?> GetDirectorByIdAsync(Guid id);
        Task<AddDirectorViewModel> GetNewAddDirectorModelAsync();
    }
}
