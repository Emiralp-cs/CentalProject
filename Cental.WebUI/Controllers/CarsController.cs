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

namespace Cental.WebUI.Controllers
{   //TODO:Filter cars metodu Solide uygun olabilmesi için Business Katmanından metod olarak getirilecek.
    [AllowAnonymous]
    public class CarsController(ICarService _carService, IBrandService _brandService, CentalContext _context) : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Cars";


            if (TempData["FilterCars"] != null)
            {
                var data = TempData["FilterCars"].ToString();
                if (data != null)
                {
                    var filterCars = JsonSerializer.Deserialize<List<Car>>(data, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles
                    });
                    return View(filterCars);

                }
            }
            var values = _carService.TGetAll();
            return View(values);

        }


        [HttpPost]
        public IActionResult Tasiyici(string ImageUrl, string Price, int SeatCount, string GearType, string GasType, int Year, int Kilometer, string BrandAndModel,string Review,string Transmission)
        {

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


        //[HttpPost]
        //public IActionResult Deneme()
        //{
        //    TempData["Mesaj"] = "Ahmet";
        //    return RedirectToAction("Index", "Booking");
        //}





        [HttpPost]
        public IActionResult FilterCars(string brand, string gear, string gas, int year)
        {
            IQueryable<Car> values = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(brand))
            {
                values = values.Where(x => x.Brand.BrandName == brand);

            }

            if (!string.IsNullOrEmpty(gear))
            {
                values = values.Where(x => x.GearType == gear);

            }

            if (!string.IsNullOrEmpty(gas))
            {
                values = values.Where(x => x.GasType == gas);

            }

            if (year > 0)
            {
                values = values.Where(x => x.Year >= year);

            }

            var filterList = values.ToList();
            TempData["FilterCars"] = JsonSerializer.Serialize(filterList, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            return RedirectToAction("Index");
        }
    }
}

