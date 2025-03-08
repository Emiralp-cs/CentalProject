using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UITestimonialComponent(IReviewService _reviewService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var reviewList = _reviewService.TListN();
            return View(reviewList);
        }

    }
}
