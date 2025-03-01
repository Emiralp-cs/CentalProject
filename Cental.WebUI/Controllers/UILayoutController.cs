using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class UILayoutController(UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> UILayout()
        {

            if (User.Identity.IsAuthenticated)
            {   

                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var userRoles = await _userManager.GetRolesAsync(user);

                ViewBag.IsAuthenticated = "true";

                foreach (var role in userRoles) 
                {
                    if (role == "Admin")
                    {
                        
                    }
                }
            }



            return View();
        }
    }
}
