using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UILayoutUsersPanels(UserManager<AppUser> _userManager) : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var userRoles = await _userManager.GetRolesAsync(user);

                ViewBag.IsAuthenticated = "true";


                foreach (var role in userRoles) 
                {
                    if (role == "User")
                    {
                        ViewBag.RoleUrl = "/User/UserCar/Index";
                    }

                    else if (role == "Manager")
                    {
                        ViewBag.RoleUrl = "/Manager/ManagerCar/Index";
                    }

                    else if(role == "Admin")
                    {
                        ViewBag.RoleUrl = "/Admin/AdminProfile/Index";
                    }

                }

            }
            else
            {
                ViewBag.RoleUrl = "/Login/SignIn";
            }

            return View();  
        }
    }
}
