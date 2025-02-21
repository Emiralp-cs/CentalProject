using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{

    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ManagerCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
