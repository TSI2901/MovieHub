using Microsoft.AspNetCore.Mvc;
using MovieHub.Contracts;
using static MovieHub.Common.GeneralApplicationConstants;
using MovieHub.Services;
using MovieHub.ViewModels;

namespace Movie_Hub.Controllers
{
    public class ActorController : BaseController
    {
        private readonly IActorService actorService;
        public ActorController(IActorService service)
        {
            this.actorService = service;
        }

        //Add actor
        [HttpGet]
        public async Task<IActionResult> AddActor(Guid Id)
        {
            var model = await actorService.GetNewAddActorModelAsync();

            ViewData["MovieId"] = Id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddActor(AddActorViewModel model, Guid Id)
        {
           
            await actorService.AddActorAsync(model, Id);
            return RedirectToAction("All", "Library");
        }

        //Show actor details
        public async Task<IActionResult> ActorDetails(Guid id)
        {
            var mdoel = await actorService.GetActorByIdAsync(id);

            if (mdoel == null)
            {
                return RedirectToAction("All", "Library");
            }

            return View(mdoel);
        }

        //Edit actor
        [HttpGet]
        public async Task<IActionResult> EditActor(Guid id)
        {
            var model = await actorService.GetActorByIdForEditAsync(id);

            if (model == null || !User.IsInRole(AdminRole))
            {
                return RedirectToAction("All", "Library");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditActor(AddActorViewModel model)
        {

            await actorService.EditActorAsync(model);
            return RedirectToAction("All", "Library");
        }
        //Delete actor
        public async Task<IActionResult> DeleteActor(Guid Id)
        {
            if (User.IsInRole(AdminRole))
            {
                await actorService.DeleteActorAsync(Id);
                
            }
            return RedirectToAction("All", "Library");
        }
    }
}
