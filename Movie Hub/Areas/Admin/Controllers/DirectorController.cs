using Microsoft.AspNetCore.Mvc;
using MovieHub.Contracts;
using MovieHub.ViewModels;
using static MovieHub.Common.GeneralApplicationConstants;


namespace Movie_Hub.Areas.Admin.Controllers
{
    public class DirectorController : BaseAdminController
    {
        private readonly IDirectorService directorService;
        public DirectorController(IDirectorService service)
        {
            this.directorService = service;
        }


        //Add Director
        [HttpGet]
        public async Task<IActionResult> AddDirector(Guid Id)
        {
            var model = await directorService.GetNewAddDirectorModelAsync();

            ViewData["MovieId"] = Id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddDirector(AddDirectorViewModel model, Guid Id)
        {

            await directorService.AddDirectorAsync(model, Id);
            return RedirectToAction("All", "Library");
        }
        //Edit director
        [HttpGet]
        public async Task<IActionResult> EditDirector(Guid id)
        {
            var model = await directorService.GetDirectorByIdForEditAsync(id);

            if (model == null || !User.IsInRole(AdminRole))
            {
                return RedirectToAction("All", "Library");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditDirector(AddDirectorViewModel model)
        {

            await directorService.EditDirectorAsync(model);
            return RedirectToAction("All", "Library");
        }
        //Delete director
        public async Task<IActionResult> DeleteDirector(Guid Id)
        {
            if (User.IsInRole(AdminRole))
            {
                await directorService.DeleteDirectorAsync(Id);

            }
            return RedirectToAction("All", "Library");
        }
        
    }
}
