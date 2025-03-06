using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UIServicesComponent(IServicesService _servicesService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var services = _servicesService.TGetAll();
            return View(services);
        }

    }
}
