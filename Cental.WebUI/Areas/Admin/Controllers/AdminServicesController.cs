using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminServicesController(IServicesService _servicesService) : Controller
    {
        public IActionResult Index()
        {
            var servicesList = _servicesService.TGetAll();


            return View(servicesList);
        }


        [HttpGet]
        public IActionResult UpdateService(int Id)
        {
            var currentService = _servicesService.TGetById(Id);


            return View(currentService);
        }


        [HttpPost]
        public IActionResult UpdateService(Service updateService)
        {

            if (!ModelState.IsValid)
            {
                return View(updateService);
            }
            else
            {   



                _servicesService.TUpdate(updateService);
                return RedirectToAction("Index");

            }


        }




    }
}
