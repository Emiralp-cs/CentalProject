using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserCarController(ICarService _carService, IBrandService _brandService, RoleManager<AppRole> _roleManager, UserManager<AppUser> _userManager, IImageService _imageService, IBookingService _bookingService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var userBookings = _bookingService.TGetAll().Where(x => x.UserId == user.Id).ToList();

            if (userBookings.Count == 0)
            {
                TempData["BookingCountError"] = "Henüz Bir Aracı Kiralama Talebiniz Bulunmuyor!";
                return View();
            }

            return View(userBookings);
        }

        [HttpGet]
        public async Task<IActionResult> RentDetails(int id)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var booking = _bookingService.TGetAll().Where(x => x.UserId == user.Id).FirstOrDefault();

            return View(booking);
        }



    }
}
