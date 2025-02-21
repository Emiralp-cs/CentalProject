using Cental.DTOLayer.CarDtos;
using Cental.DTOLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cental.WebUI.Controllers
{

    [AllowAnonymous]
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            string mesaj = TempData["Mesaj"] as string;


            string ImageUrl = TempData["ImageUrl"] as string;
            string Price = TempData["Price"] as string;
            int SeatCount = (int)TempData["SeatCount"];
            string GearType = TempData["GearType"] as string;
            string GasType = TempData["GasType"] as string;
            int Year = (int)TempData["Year"];
            int Kilometer = (int)TempData["Kilometer"];
            string BrandAndModel = TempData["BrandAndModel"] as string;
            string Review = TempData["Review"] as string;
            string Transmission = TempData["Transmission"] as string;


            ViewBag.mesaj = mesaj;

            ViewBag.ImageUrl = ImageUrl;
            ViewBag.Price = Price;
            ViewBag.SeatCount = SeatCount;
            ViewBag.GearType = GearType;
            ViewBag.GasType = GasType;
            ViewBag.Year = Year;
            ViewBag.Kilometer = Kilometer;
            ViewBag.BrandAndModel = BrandAndModel;
            ViewBag.Review = Review;
            ViewBag.Transmission = Transmission;

            return View();
        }
    }
}
