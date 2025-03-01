
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
{
    [AllowAnonymous]
    public class CarsController(ICarService _carService, IBrandService _brandService, CentalContext _context, IBookingService _bookingService) : Controller
    {
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



            var bookingvalues = _bookingService.TGetAll().Where(x => x.IsApproved ==true).Select(x => x.CarId).ToList();
            var values = _carService.TGetAll().Select(x => x.CarId).ToList();

            var carvalues = _carService.TGetAll();

            var result = values.Except(bookingvalues).ToList();


            List<Car> result1 = carvalues.Where(car => result.Contains(car.CarId)).ToList();

            return View(result1);

        }

        [HttpPost]
        public IActionResult FilterCars(string brand, string gear, string gas, int year)
        {
            IQueryable<Car> values = _context.Cars.AsQueryable(); //filtrelenebilir bir liste oluşturduk.
            //asqueryable kullandık çünkü value içerisinde şartlı sorgulama yani where koşullarını kullanabilmek için.

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

            var filterList = values.ToList(); //filtrelenebilir listeyi normal listeye çevirdik
            //Iquaryable tipinde olduğu için listeye çeviriyoruz çünkü view'e liste tipinde veri taşıyacağız.
            //farklı view'e taşıyacağımız için TempData kullanıyoruz.   
            //tempdata tipini bilemeyeceğimiz için json formatına çevirip taşıyoruz.
            //ilişkili tablo olduğu için döngüye girmemesi adına ReferenceHandler.IgnoreCycles kullanıyoruz.
            TempData["FilterCars"] = JsonSerializer.Serialize(filterList, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            return RedirectToAction("Index");
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
