using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UIStatisticsComponent(IBrandService _brandService, ICarService _carService, UserManager<AppUser> _userManager, IReviewService _reviewService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Kaç Tane Araba Olduğu Getirilecek
            var totalCarCount = _carService.TGetAll().Count;
            ViewBag.TotalCarCount = totalCarCount;
            //Kaç Tane Kayıtlı Kullanıcı Olduğu Getirilecek
            var totalUserCount = await _userManager.Users.ToListAsync();
            ViewBag.TotalUserCount = totalUserCount.Count;
            //Kullanıcı Değerlendirme Ortalaması Getirilecek

            if (_reviewService.TGetAll().Count != 0)
            {
                var userReviewAvg = _reviewService.TGetAll().Average(x => x.Rating);
                ViewBag.UserReviewAvg = userReviewAvg.ToString("F1").Replace(",", ".");
            }

            else
            {
                ViewBag.UserReviewAvg = 0;
            }


            //Toplam Marka Sayısı Getirilecek
            var totalBrandCount = _brandService.TGetAll().Count;
            ViewBag.BrandCount = totalBrandCount;


            ViewBag.UserReviewAvg = 0;









            return View();
        }

    }
}
