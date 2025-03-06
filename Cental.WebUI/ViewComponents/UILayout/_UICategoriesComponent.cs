using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UICategoriesComponent(ICarService _carService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var carList = _carService.TGetAll();

            

            return View(carList);
        }

    }
}
