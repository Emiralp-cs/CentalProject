using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Cental.WebUI.Areas.User.Controllers
{

    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserReviewController(IReviewService _reviewService, IBookingService _bookingService, UserManager<AppUser> _userManager, ICarService _carService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var BookingList = _bookingService.TGetAll().Where(x => x.IsApproved == true && x.UserId == user.Id).ToList();

            if (BookingList.Count == 0)
            {
                TempData["BookingListZeroError"] = "Henüz Kiralanmış Arabanız Bulunmuyor.";
                return View();
            }
            return View(BookingList);
        }

        [HttpGet]
        public async Task<IActionResult> Deneme(int id)
        {
            var Car = _carService.TGetById(id);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var reviewList = _reviewService.TGetAll();

            if (reviewList.Where(x => x.UserId == user.Id && x.CarId == id).Any())
            {
                TempData["ReviewError"] = "Bu Araca Zaten Yorum Yaptınız";

                var review = _reviewService.TGetAll().Where(x => x.UserId == user.Id).FirstOrDefault();

                ViewBag.Stars = review.Rating;

                ViewBag.Review = review.Comment;

                ViewBag.ReviewId = review.ReviewId;

                return View(Car);
            }

            ViewBag.RatingStars = _reviewService.TGetStarList();

            ViewBag.Denemee = id;

            ViewBag.Car = Car;

            return View(Car);
        }


        [HttpPost]
        public async Task<IActionResult> Deneme(Review newReview)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            newReview.UserId = user.Id;


            if (string.IsNullOrEmpty(newReview.Comment) && newReview.Rating == 0)
            {
                var Car = _carService.TGetById(newReview.CarId);
                ViewBag.Comment = "Yorum Kısmı Boş Geçilemez!";
                ViewBag.RatingStars = _reviewService.TGetStarList();
                ViewBag.CheckRating = "Puan Verme Kısmı Boş Geçilemez!";
                return View(Car);
            }


            else if (string.IsNullOrEmpty(newReview.Comment))
            {
                var Car = _carService.TGetById(newReview.CarId);
                ViewBag.Comment = "Yorum Kısmı Boş Geçilemez!";
                ViewBag.RatingStars = _reviewService.TGetStarList();
                return View(Car);
            }

            else if (newReview.Rating == 0)
            {
                ViewBag.CommentValue = newReview.Comment;
                ViewBag.RatingStars = _reviewService.TGetStarList();
                var Car = _carService.TGetById(newReview.CarId);
                ViewBag.CheckRating = "Puan Verme Kısmı Boş Geçilemez!";

                return View(Car);
            }





            _reviewService.TCreate(newReview);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult EditReview(int id)
        {
            var editReview = _reviewService.TGetById(id);
            ViewBag.RatingStars = _reviewService.TGetStarList();

            return View(editReview);
        }



        [HttpPost]
        public async Task<IActionResult> EditReview(Review updateReview)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            updateReview.UserId = user.Id;

            ViewBag.RatingStars = _reviewService.TGetStarList();
            if (string.IsNullOrEmpty(updateReview.Comment) && updateReview.Rating == 0)
            {
                var Car = _carService.TGetById(updateReview.CarId);
                ViewBag.Comment = "Yorum Kısmı Boş Geçilemez!";
                ViewBag.RatingStars = _reviewService.TGetStarList();
                ViewBag.CheckRating = "Puan Verme Kısmı Boş Geçilemez!";
                return View(Car);
            }


            else if (string.IsNullOrEmpty(updateReview.Comment))
            {
                var Car = _carService.TGetById(updateReview.CarId);
                ViewBag.Comment = "Yorum Kısmı Boş Geçilemez!";
                ViewBag.RatingStars = _reviewService.TGetStarList();
                return View(Car);
            }

            else if (updateReview.Rating == 0)
            {
                ViewBag.CommentValue = updateReview.Comment;
                ViewBag.RatingStars = _reviewService.TGetStarList();
                var Car = _carService.TGetById(updateReview.CarId);
                ViewBag.CheckRating = "Puan Verme Kısmı Boş Geçilemez!";

                return View(Car);
            }


            _reviewService.TUpdate(updateReview);




            return RedirectToAction("Index");
        }

    }
}
