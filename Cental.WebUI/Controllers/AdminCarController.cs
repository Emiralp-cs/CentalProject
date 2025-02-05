using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Extensions.Enums;
using Cental.DataAccessLayer.Concrate;
using Cental.DTOLayer.CarDtos;
using Cental.DTOLayer.Enums;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IBrandService _brandService;

        private readonly ICarService _carService;

        private readonly IMapper _mapper;
        public AdminCarController(ICarService carService, IMapper mapper, IBrandService brandService)
        {
            _carService = carService;
            _mapper = mapper;
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var result = _carService.TListN();

            return View(result);
        }


        [HttpGet]
        public IActionResult CreateCar()
        {

            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
            ViewBag.transmissionTypes = GetEnumValues.GetEnums<TransmissionTypes>();
            ViewBag.brands = (from x in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text = x.BrandName,
                                  Value = x.BrandId.ToString()

                              }).ToList();

            return View();
        }


        [HttpPost]
        public IActionResult CreateCar(CreateCarDto NewCar)
        {




            _carService.TCreateN(NewCar);



            return RedirectToAction("Index");
        }
    }
}
