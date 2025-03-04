using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminSubscribeController(ISubscribeService _subscribeService) : Controller
    {

        
        public IActionResult Index()
        {

            var subscribeList = _subscribeService.TGetAll();

            return View(subscribeList);
        }


        public IActionResult DeleteSubscribe(int id) 
        {

            _subscribeService.TDelete(id);


            return RedirectToAction("Index");
        }

    }
}
