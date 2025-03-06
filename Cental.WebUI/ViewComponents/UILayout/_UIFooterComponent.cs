using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UIFooterComponent(IFooterService _footerService) : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var footerList = _footerService.TGetAll();
            return View(footerList);
        }
    }
}
