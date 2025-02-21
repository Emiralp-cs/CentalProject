using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminFeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        private readonly IMapper _mapper;

        public AdminFeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var values = _featureService.TGetAll();

            var result = _mapper.Map<List<ToListFeatureDTO>>(values);

            return View();
        }

        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var value = _featureService.TGetById(id);

            var DtoFeature = _mapper.Map<UpdateFeatureDTO>(value);

            return View(DtoFeature);
        }

        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureDTO dto)
        {

            var value = _mapper.Map<Feature>(dto);

            _featureService.TUpdate(value);


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO newFeature)
        {

            var Mapping = _mapper.Map<Feature>(newFeature);

            _featureService.TCreate(Mapping);

            return RedirectToAction("Index");
        }

    }
}
