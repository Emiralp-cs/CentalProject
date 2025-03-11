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
        public IActionResult RentDetails(int id)
        {
            var currentBooking = _bookingService.TGetById(id);

            return View(currentBooking);
        }

        public IActionResult DeleteBooking(int id)
        {

            var currentBooking = _bookingService.TGetById(id);

            if (currentBooking.IsApproved == true)
            {
                TempData["ApprovedDeleteError"] = "Aracın Kira Durumu Onaylandığı İçin İptal Edemesiniz Detaylı Bilgi İçin Araç Sahibi İle İletişime Geçiniz";
                return RedirectToAction("RentDetails", new { id });
            }
            TempData["SuccessMessage"] = "Kiralama kaydı başarıyla silindi.";

            _bookingService.TDelete(id);


            return RedirectToAction("Index");
        }



    }
}
