using Microsoft.AspNetCore.Mvc;
using MovieHub.Contracts;

namespace Movie_Hub.Controllers
{
    public class LibraryController : BaseController
    {
        private readonly ILibraryService service;

        public LibraryController(ILibraryService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var models =  await service.GetAllMovies();
            return View(models);
        }
        
        public IActionResult Add()
        {
            return View();
        }
    }
}
