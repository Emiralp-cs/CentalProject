using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UserLayout
{
    public class _UserLayoutSideBarComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _UserLayoutSideBarComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.nameSurname = string.Join(" ", user.FirstName, user.LastName);
            ViewBag.userImage = user.ProfilePicture;


            return View();
        }
    }
}
