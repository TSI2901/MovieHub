using Microsoft.AspNetCore.Mvc;
using MovieHub.Contracts;
using MovieHub.ViewModels;
using static MovieHub.Common.GeneralApplicationConstants;

namespace Movie_Hub.Areas.Admin.Controllers
{
    public class ActorController : BaseAdminController
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
