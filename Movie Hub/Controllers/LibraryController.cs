using Microsoft.AspNetCore.Mvc;
using MovieHub.Contracts;
using MovieHub.ViewModels;

namespace Movie_Hub.Controllers
{
    public class LibraryController : BaseController
    {
        private readonly ILibraryService LibraryService;

        public LibraryController(ILibraryService service)
        {
            this.LibraryService = service;
        }

        public async Task<IActionResult> All()
        {
            var models =  await LibraryService.GetAllMovies();
            return View(models);
        }
        public async Task<IActionResult> Liked()
        {
            var models = await LibraryService.GetLikedMovies(GetUserID());
            return View(models);
        }

        
        
    }
}
