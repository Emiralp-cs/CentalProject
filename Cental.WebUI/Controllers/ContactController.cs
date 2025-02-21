using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Contact";
            return View();
        }


        public IActionResult SendMessage()
        {
            return NoContent();
        }
    }
}
