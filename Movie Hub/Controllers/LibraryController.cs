using Microsoft.AspNetCore.Mvc;

namespace Movie_Hub.Controllers
{
    public class LibraryController : BaseController
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
