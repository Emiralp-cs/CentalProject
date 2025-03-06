using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UIFeatureComponent(IFeatureService _featureService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

          var featureList =  _featureService.TListN();

            return View(featureList);
        }

    }
}
