using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UIManagerComponent(UserManager<AppUser> _userManager) : ViewComponent
    {   

        
        public async Task<IViewComponentResult> Invoke()
        {
            var managers = await _userManager.GetUsersInRoleAsync("Manager");

            return View();
        }
    }
}
