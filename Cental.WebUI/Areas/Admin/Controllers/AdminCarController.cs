using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCarController(IImageService _imageService, ICarService _carService, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var managerUserList = new List<AppUser>();

            var userList = await _userManager.Users.ToListAsync();

            foreach (var user in userList)
            {
                var userRole = await _userManager.GetRolesAsync(user);

                foreach (var role in userRole)
                {
                    if (role == "Manager")
                    {
                        managerUserList.Add(user);
                    }

                }

            }



            return View(managerUserList);
        }

        [HttpGet]
        public IActionResult CarList(int id)
        {

            var currentManagerCarList = _carService.TGetAll().Where(x => x.User.Id == id).ToList();

            if (currentManagerCarList.Count == 0)
            {
                TempData["CarCountError"] = "Henüz Araç Eklenmemiş.";
            }


            return View(currentManagerCarList);
        }




    }
}
