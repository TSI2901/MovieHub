using Microsoft.AspNetCore.Mvc;
using MovieHub.Contracts;
using MovieHub.ViewModels;
using static MovieHub.Common.GeneralApplicationConstants;

namespace Movie_Hub.Areas.Admin.Controllers
{
    public class MovieController : BaseAdminController
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService service)
        {
            this.movieService = service;
        }
        //Add movie 
        [HttpGet]
        public async Task<IActionResult> AddMovie()
        {
            var model = await movieService.GetNewAddMovieModelAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieViewModel model)
        {
            
            await movieService.AddMovieAsync(model);
            return RedirectToAction("All", "Library");
        }





        //Show movie details
        public async Task<IActionResult> MovieDetails(Guid id)
        {
            var mdoel = await movieService.GetMovieByIdAsync(id);

            if (mdoel == null)
            {
                return RedirectToAction("All", "Library");
            }

            return View(mdoel);
        }



        //Edit movie
        [HttpGet]
        public async Task<IActionResult> EditMovie(Guid id)
        {
            var model = await movieService.GetMovieByIdForEditAsync(id);

            if (model == null || User.IsInRole(AdminRole))
            {
                return RedirectToAction("All", "Library");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditMovie(AddMovieViewModel model)
        {

            await movieService.EditMovieAsync(model);
            return RedirectToAction("All", "Library");
        }

        //Delete movie
        public async Task<IActionResult> DeleteMovie(Guid Id)
        {
            if (User.IsInRole(AdminRole))
            {
                await movieService.DeleteMovieAsync(Id);
            }
            
            return RedirectToAction("All", "Library");
        }

    }
}
