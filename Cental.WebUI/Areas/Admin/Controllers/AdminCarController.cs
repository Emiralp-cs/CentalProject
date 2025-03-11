using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCarController(IImageService _imageService, ICarService _carService, UserManager<AppUser> _userManager, IReviewService _reviewService, IBookingService _bookingService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var managerUserList = await _userManager.GetUsersInRoleAsync("Manager");
            return View(managerUserList);
        }

        [HttpGet]
        public IActionResult CarList(int id)
        {
            var currentManagerCarList = _carService.TGetAll().Where(x => x.User.Id == id).ToList();

            if (currentManagerCarList.Count == 0)
            {
                TempData["CarCountError"] = "Henüz Araç Eklenmemiş.";
            }

            return View(currentManagerCarList);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var currentCar = _carService.TGetById(id);

            currentCar.Bookings = _bookingService.TGetAll().Where(b => b.CarId == id).ToList();
            return View(currentCar);
        }

        public IActionResult DeleteComment(int id)
        {
            var currentReview = _reviewService.TGetById(id);
            var carId = currentReview.CarId;
            _reviewService.TDelete(id);
            return RedirectToAction("Details", new { id = carId });
        }

        [HttpGet]
        public IActionResult EditComment(int id)
        {
            var currentReview = _reviewService.TGetById(id);
            return View(currentReview);
        }

        [HttpPost]
        public IActionResult EditComment(Review editReview)
        {
            _reviewService.TUpdate(editReview);
            return RedirectToAction("Details", new { id = editReview.CarId });
        }
    }
}