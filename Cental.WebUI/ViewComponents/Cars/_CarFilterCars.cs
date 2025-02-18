using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Extensions.Enums;
using Cental.DTOLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.Cars
{   

    public class _CarFilterCars(IBrandService _brandService) : ViewComponent
    {   
        public IViewComponentResult Invoke()
        {
            var brands = _brandService.TGetAll();

            ViewBag.brands = (from x in brands
                              select new SelectListItem
                              {
                                  Text = x.BrandName,
                                  Value = x.BrandName
                              }).ToList();

            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();

            return View();
        }
    }
}
