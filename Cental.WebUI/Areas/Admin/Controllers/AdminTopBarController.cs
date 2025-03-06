using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.TopBarDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminTopBarController(ITopBarService _topBarService) : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {   

            var topBar = _topBarService.TGetAll().FirstOrDefault();

            return View(topBar);
        }

        [HttpPost]
        public IActionResult Index(TopBar UpdateTopBar)
        {

            if (!ModelState.IsValid) 
            {
                
                return View();
            }
            else
            {
                _topBarService.TUpdate(UpdateTopBar);

                return View();

            }
            
        }

    }
}
