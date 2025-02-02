using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IBrandService _brandService;

        private readonly IMapper _mapper;

        public AdminBrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _brandService.TGetAll();

            var result = _mapper.Map<List<ToListBrandDTO>>(values);

            return View(result);
        }


        public IActionResult DeleteBrand(int id)
        {
            _brandService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(CreateBrandDTO NewBrand)
        {
            if (!ModelState.IsValid)
            {
                return View(NewBrand);
            }


            var result = _mapper.Map<Brand>(NewBrand);

            _brandService.TCreate(result);

            return RedirectToAction("Index");
        }
    }
}
