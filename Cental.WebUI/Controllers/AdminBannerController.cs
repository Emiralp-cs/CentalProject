using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminBannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;

        public AdminBannerController(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _bannerService.TGetAll();
            //Auto Mapping
            var banners = _mapper.Map<List<ToListBannerDto>>(values);


            return View(banners);
        }
        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBanner(CreateBannerDto newBanner)
        {
            var banner = _mapper.Map<Banner>(newBanner);

            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }
    }
}
