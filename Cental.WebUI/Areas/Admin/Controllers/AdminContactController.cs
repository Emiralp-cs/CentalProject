using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminContactController(IContactService _contactService) : Controller
    {


        public IActionResult Index()
        {

            var reviewList = _contactService.TGetAll();

            if (reviewList.Count == 0)
            {
                TempData["ReviewListCountError"] = "Mesaj Bulunmuyor!";
                return View();
            }


            return View(reviewList);
        }

        [HttpGet]
        public IActionResult MessageDetail(int id)
        {
            var currentMessage = _contactService.TGetById(id);



            return View(currentMessage);
        }

        public IActionResult Isreaded(int id)
        {
            var currentMessage = _contactService.TGetById(id);

            if (currentMessage.Isreaded == false)
            {
                currentMessage.Isreaded = true;
            }

            else if (currentMessage.Isreaded == true)
            {
                currentMessage.Isreaded = false;
            }
            _contactService.TUpdate(currentMessage);

            return RedirectToAction("Index");
        }

        public IActionResult MessageDelete(int id)
        {

            _contactService.TDelete(id);

            return RedirectToAction("Index");
        }


    }
}
