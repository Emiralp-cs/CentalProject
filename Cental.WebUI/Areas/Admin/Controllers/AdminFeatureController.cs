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

    public class AdminFeatureController(IFeatureService _featureService) : Controller
    {
        
        public IActionResult Index()
        {
            var featureList = _featureService.TListN();

            return View(featureList);
        }


        [HttpGet]
        public IActionResult EditFeature(int id)
        {

            var currentFeature = _featureService.TUpdate_GetN(id);

            return View(currentFeature);
        }


        [HttpPost]
        public IActionResult EditFeature(UpdateFeatureDTO feature)
        {

            if (!ModelState.IsValid) 
            {
                
                return View(feature);
            }


            _featureService.T_Update_PostN(feature);

            return RedirectToAction("Index");
        }

    }
}
