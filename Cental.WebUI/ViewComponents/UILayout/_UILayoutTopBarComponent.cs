using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UILayoutTopBarComponent(ITopBarService _topBarService) : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var currentTopBar = _topBarService.TGetAll().FirstOrDefault();

            return View(currentTopBar);
        }
    }
}
