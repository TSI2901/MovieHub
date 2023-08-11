using MovieHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Contracts
{
    public interface IActorService
    {
        Task EditActorAsync(AddActorViewModel model);
        Task<AddActorViewModel?> GetActorByIdForEditAsync(Guid Id);
        Task AddActorAsync(AddActorViewModel actor, Guid Id);
        Task DeleteActorAsync(Guid actorId);
        Task<ActorDetailsViewModel?> GetActorByIdAsync(Guid id);
        Task<AddActorViewModel> GetNewAddActorModelAsync();
    }
}
