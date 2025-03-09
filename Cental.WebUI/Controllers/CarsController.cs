
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Extensions.Enums;
using Cental.DataAccessLayer.Context;
using Cental.DTOLayer.Enums;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json.Serialization;
using System.Text.Json;
using Cental.DTOLayer.CarDtos;
using AutoMapper;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class CarsController(ICarService _carService, IBrandService _brandService, IBookingService _bookingService) : Controller
    {
        public IActionResult Index(string? modelName, string? brand, string? gasType, string? gearType, int? year, int? price, int? kilometer)
        {
            ViewBag.ActivePage = "Cars";
            var bookingvalues = _bookingService.TGetAll().Where(x => x.IsApproved == true).Select(x => x.CarId).ToList();
            var values = _carService.TGetAll().Select(x => x.CarId).ToList();

            var carvalues = _carService.TGetAll();

            var result = values.Except(bookingvalues).ToList();
            List<Car> result1 = carvalues.Where(car => result.Contains(car.CarId)).ToList();

            if (!string.IsNullOrEmpty(modelName))
            {
                result1 = result1.Where(x => x.ModelName.ToLower() == modelName.ToLower()).ToList();
            }
            if (!string.IsNullOrEmpty(brand))
            {
                result1 = result1.Where(x => x.Brand.BrandName == brand.ToString()).ToList();
            }
            if (!string.IsNullOrEmpty(gasType))
            {
                result1 = result1.Where(x => x.GasType == gasType.ToString()).ToList();
            }
            if (!string.IsNullOrEmpty(gearType))
            {
                result1 = result1.Where(x => x.GearType == gearType.ToString()).ToList();
            }
            if (year > 0)
            {
                result1 = result1.Where(x => x.Year >= year).ToList();
            }
            if (kilometer > 0)
            {
                result1 = result1.Where(x => x.Kilometer >= kilometer).ToList();
            }
            if (price > 0)
            {
                result1 = result1.Where(x => x.Price >= price).ToList();
            }




            return View(result1);

        }




        [HttpPost]
        public IActionResult Tasiyici(string ImageUrl, string Price, string SeatCount, string GearType, string GasType, string Year, string Kilometer, string BrandAndModel, string Review, string Transmission, string CarId)
        {
            TempData["CarId"] = CarId;
            TempData["ImageUrl"] = ImageUrl;
            TempData["Price"] = Price;
            TempData["SeatCount"] = SeatCount;
            TempData["GearType"] = GearType;
            TempData["GasType"] = GasType;
            TempData["Year"] = Year;
            TempData["Kilometer"] = Kilometer;
            TempData["BrandAndModel"] = BrandAndModel;
            TempData["Review"] = Review;
            TempData["Transmission"] = Transmission;


            return RedirectToAction("Index", "Booking");
        }
    }


}
