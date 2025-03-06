using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminFooterController(IFooterService _footerService) : Controller
    {
        public IActionResult Index()
        {
            var footer = _footerService.TGetAll();
            return View(footer);
        }

        [HttpGet]
        public IActionResult UpdateFooter(int Id)
        {
            var currentFooter = _footerService.TGetById(Id);

            return View(currentFooter);
        }


        [HttpPost]
        public IActionResult UpdateFooter(Footer updateFooter)
        {
            if (!ModelState.IsValid)
            {
                return View(updateFooter);
            }

            else
            {
                _footerService.TUpdate(updateFooter);
                return RedirectToAction("Index");

            }
        }
    }
}
