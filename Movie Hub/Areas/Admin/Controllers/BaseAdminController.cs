using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static MovieHub.Common.GeneralApplicationConstants;
namespace Movie_Hub.Areas.Admin.Controllers
{
    [Area(AdminArea)]
    [Authorize(Roles = AdminRole)]
    public class BaseAdminController : Controller
    {
        public string GetUserID()
        {
            string id = string.Empty;
            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return id;
        }
    }
}