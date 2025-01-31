﻿using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UIFeatureComponent : ViewComponent
    {
        private readonly IMapper _mapper;

        private readonly IFeatureService _featureService;

        public _UIFeatureComponent(IMapper mapper, IFeatureService featureService)
        {
            _mapper = mapper;
            _featureService = featureService;
        }

        public IViewComponentResult Invoke()
        {

            return View();
        }



    }
}
