using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController(IDashboardService _dashboardService) : Controller
    {

        public IActionResult Index()
        {
            ViewBag.TotalUserCount = _dashboardService.TotalUserCountT();

            ViewBag.TotalBrandCount = _dashboardService.TotalBrandCountT();

            ViewBag.TotalCarCount = _dashboardService.TotalCarCountT();

            ViewBag.TotalMessageCount = _dashboardService.TotalMessageCountT();

            ViewBag.TotalBookingCount = _dashboardService.TotalBookingCountT();

            ViewBag.ApprovedBookingCount = _dashboardService.ApprovedBookingCountT();

            ViewBag.DeclinedBookingCount = _dashboardService.DeclinedBookingCountT();

            ViewBag.WaitingBookingCount = _dashboardService.WaitingBookingCountT();

            ViewBag.TotalReviewCount = _dashboardService.TotalReviewCountT();

            ViewBag.UserReviewAverage = _dashboardService.UserReviewAverageT();

            ViewBag.WaitingBookingList = _dashboardService.WaitingBookingsListT();

            ViewBag.LastAddedCarList = _dashboardService.LastAddedCarsT();

            ViewBag.LastReviewsList = _dashboardService.LastReviewsT();

            return View();
        }
    }
}
