using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DTOLayer.BookingDtos;
using Cental.DTOLayer.Enums;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController(UserManager<AppUser> userManager, IBookingService bookingService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "";

            if (TempData["userNullError"] != null)
            {
                ViewBag.userNullError = TempData["userNullError"];
            }

            // TempData'dan değerleri okuyun ve ViewBag'e atayın
            ViewBag.ImageUrl = TempData.Peek("ImageUrl") as string;
            ViewBag.Price = TempData.Peek("Price") as string;
            ViewBag.SeatCount = TempData.Peek("SeatCount") as string;
            ViewBag.GearType = TempData.Peek("GearType") as string;
            ViewBag.GasType = TempData.Peek("GasType") as string;
            ViewBag.Year = TempData.Peek("Year") as string;
            ViewBag.Kilometer = TempData.Peek("Kilometer") as string;
            ViewBag.BrandAndModel = TempData.Peek("BrandAndModel") as string;
            ViewBag.Review = TempData.Peek("Review") as string;
            ViewBag.Transmission = TempData.Peek("Transmission") as string;
            ViewBag.CarId = TempData.Peek("CarId") as string;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto BookCar)
        {

            




            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.ImageUrl = TempData.Peek("ImageUrl") as string;
                ViewBag.Price = TempData.Peek("Price") as string;
                ViewBag.SeatCount = TempData.Peek("SeatCount") as string;
                ViewBag.GearType = TempData.Peek("GearType") as string;
                ViewBag.GasType = TempData.Peek("GasType") as string;
                ViewBag.Year = TempData.Peek("Year") as string;
                ViewBag.Kilometer = TempData.Peek("Kilometer") as string;
                ViewBag.BrandAndModel = TempData.Peek("BrandAndModel") as string;
                ViewBag.Review = TempData.Peek("Review") as string;
                ViewBag.Transmission = TempData.Peek("Transmission") as string;
                ViewBag.CarId = TempData.Peek("CarId") as string;
                ViewBag.UserNullError = "Araç Kiralamak İçin Siteye Kayıt Olmanız Gerekmektedir!";

                return View();

            }




            var startDate = BookCar.PickUpDate;
            var endDate = BookCar.DropOffDate;
            TimeSpan difference = endDate - startDate;
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            BookCar.User = user;
            var bookingList = bookingService.TGetAll();


            if (!ModelState.IsValid)
            {   
                ViewBag.ImageUrl = TempData.Peek("ImageUrl") as string;
                ViewBag.Price = TempData.Peek("Price") as string;
                ViewBag.SeatCount = TempData.Peek("SeatCount") as string;
                ViewBag.GearType = TempData.Peek("GearType") as string;
                ViewBag.GasType = TempData.Peek("GasType") as string;
                ViewBag.Year = TempData.Peek("Year") as string;
                ViewBag.Kilometer = TempData.Peek("Kilometer") as string;
                ViewBag.BrandAndModel = TempData.Peek("BrandAndModel") as string;
                ViewBag.Review = TempData.Peek("Review") as string;
                ViewBag.Transmission = TempData.Peek("Transmission") as string;
                ViewBag.CarId = TempData.Peek("CarId") as string;
                return View();
            }



            if (BookCar.PickUpDate == null || BookCar.PickUpDate == default(DateTime))
            {

                ViewBag.ImageUrl = TempData.Peek("ImageUrl") as string;
                ViewBag.Price = TempData.Peek("Price") as string;
                ViewBag.SeatCount = TempData.Peek("SeatCount") as string;
                ViewBag.GearType = TempData.Peek("GearType") as string;
                ViewBag.GasType = TempData.Peek("GasType") as string;
                ViewBag.Year = TempData.Peek("Year") as string;
                ViewBag.Kilometer = TempData.Peek("Kilometer") as string;
                ViewBag.BrandAndModel = TempData.Peek("BrandAndModel") as string;
                ViewBag.Review = TempData.Peek("Review") as string;
                ViewBag.Transmission = TempData.Peek("Transmission") as string;
                ViewBag.CarId = TempData.Peek("CarId") as string;
                ViewBag.PickUpDateError = "Başlangıç Tarihi Boş Bırakılamaz!";

                return View();
            }

            if (BookCar.DropOffDate == null || BookCar.DropOffDate == default(DateTime))
            {
                ViewBag.ImageUrl = TempData.Peek("ImageUrl") as string;
                ViewBag.Price = TempData.Peek("Price") as string;
                ViewBag.SeatCount = TempData.Peek("SeatCount") as string;
                ViewBag.GearType = TempData.Peek("GearType") as string;
                ViewBag.GasType = TempData.Peek("GasType") as string;
                ViewBag.Year = TempData.Peek("Year") as string;
                ViewBag.Kilometer = TempData.Peek("Kilometer") as string;
                ViewBag.BrandAndModel = TempData.Peek("BrandAndModel") as string;
                ViewBag.Review = TempData.Peek("Review") as string;
                ViewBag.Transmission = TempData.Peek("Transmission") as string;
                ViewBag.CarId = TempData.Peek("CarId") as string;
                ViewBag.DropOffDateError = "Bitiş Tarihi Boş Bırakılamaz!";

                return View();
            }

            if (difference.Days < 0)
            {
                ViewBag.ImageUrl = TempData.Peek("ImageUrl") as string;
                ViewBag.Price = TempData.Peek("Price") as string;
                ViewBag.SeatCount = TempData.Peek("SeatCount") as string;
                ViewBag.GearType = TempData.Peek("GearType") as string;
                ViewBag.GasType = TempData.Peek("GasType") as string;
                ViewBag.Year = TempData.Peek("Year") as string;
                ViewBag.Kilometer = TempData.Peek("Kilometer") as string;
                ViewBag.BrandAndModel = TempData.Peek("BrandAndModel") as string;
                ViewBag.Review = TempData.Peek("Review") as string;
                ViewBag.Transmission = TempData.Peek("Transmission") as string;
                ViewBag.CarId = TempData.Peek("CarId") as string;
                ViewBag.DateError = "Bitiş Tarihini Başlangıç Tarihinden Önce Seçemezsiniz!";
                return View();
            }


            if (bookingList.Any(x => x.UserId == user.Id && x.CarId == int.Parse(TempData.Peek("CarId") as string)))
            {
                ViewBag.ImageUrl = TempData.Peek("ImageUrl") as string;
                ViewBag.Price = TempData.Peek("Price") as string;
                ViewBag.SeatCount = TempData.Peek("SeatCount") as string;
                ViewBag.GearType = TempData.Peek("GearType") as string;
                ViewBag.GasType = TempData.Peek("GasType") as string;
                ViewBag.Year = TempData.Peek("Year") as string;
                ViewBag.Kilometer = TempData.Peek("Kilometer") as string;
                ViewBag.BrandAndModel = TempData.Peek("BrandAndModel") as string;
                ViewBag.Review = TempData.Peek("Review") as string;
                ViewBag.Transmission = TempData.Peek("Transmission") as string;
                ViewBag.CarId = TempData.Peek("CarId") as string;
                ViewBag.BookingError = "Bir Araca En Fazla Bir Kere Kiralama İsteğinde Bulunabilirsiniz!";
                return View();

            }

            



            bookingService.TCreate(new Booking
            {
                User = user,
                CarId = int.Parse(TempData.Peek("CarId") as string),
                IsApproved = null,
                UserId = user.Id,
                PriceTimesBookingDays = difference.Days * BookCar.Price,
                PickUpDate = BookCar.PickUpDate,
                DropOffDate = BookCar.DropOffDate,
                Price = BookCar.Price,
                DropOffLocation = BookCar.DropOffLocation,
                PickUpLocation = BookCar.PickUpLocation
            });
            return RedirectToAction("Index", "Cars");


        }
    }
}