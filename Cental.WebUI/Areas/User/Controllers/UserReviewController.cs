using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Cental.WebUI.Areas.User.Controllers
{

    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserReviewController(IReviewService _reviewService, IBookingService _bookingService, UserManager<AppUser> _userManager, ICarService _carService) : Controller
    {
        public async Task<IActionResult> Index()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var BookingList = _bookingService.TGetAll().Where(x => x.IsApproved == true && x.UserId == user.Id).ToList();


            if (BookingList.Count == 0)
            {
                TempData["BookingListZeroError"] = "Henüz Kiralanmış Arabanız Bulunmuyor.";
                return View();
            }
            return View(BookingList);

        }


        [HttpGet]
        public IActionResult Deneme(int id) 
        {
            ViewBag.Denemee = id;

            return View();
        }
        



    }
}
