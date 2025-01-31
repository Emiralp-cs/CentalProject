using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.AboutDtos;
using Cental.DTOLayer.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UIAboutComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public _UIAboutComponent(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _aboutService.TGetAll();

            var result = _mapper.Map<List<UIAboutDTO>>(values);

            return View(result);
        }
    }
}
