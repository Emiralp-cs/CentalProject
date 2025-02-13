using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {   
        private readonly UserManager<AppUser> _userManager;

        public IActionResult AssignRole()
        {
            return View();
        }
    }
}
