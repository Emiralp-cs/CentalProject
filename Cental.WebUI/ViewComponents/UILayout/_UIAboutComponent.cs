﻿using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UIAboutComponent(IAboutService _aboutService) : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var aboutList = _aboutService.TListN();
            return View(aboutList);
        }
    }
}
