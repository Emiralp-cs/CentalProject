using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Concrate;
using Cental.DTOLayer.CarDtos;
using Cental.DTOLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    public class AdminCarController : Controller
    {

        private readonly ICarService _carService;

        private readonly IMapper _mapper;
        public AdminCarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _carService.TGetCarWithBrands();

            var result = _mapper.Map<List<ToListCarDto>>(values);

            return View(result);
        }


        [HttpGet]
        public IActionResult CreateCar()
        {
            var gasTypes = Enum.GetValues(typeof(GasTypes));
            
            var gasTypeSelectList = new List<SelectListItem>();

            foreach (var gasType in gasTypes) 
            {
                gasTypeSelectList.Add(new SelectListItem
                {
                    Text = gasType.ToString(),
                    Value = gasType.ToString()
                });
            }

            ViewBag.gasTypes = gasTypeSelectList;

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
