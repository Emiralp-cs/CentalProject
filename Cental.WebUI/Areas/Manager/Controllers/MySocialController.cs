using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class MySocialController(IUserSocialService _userSocialService, UserManager<AppUser>  _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _userSocialService.TGetSocialsByUserId(user.Id);

            return View(values);
        }


        [HttpGet]
        public IActionResult CreateSocial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateUserSocialDto newSocial)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            newSocial.User.Id = user.Id;
            _userSocialService.TCreateN(newSocial);

            return RedirectToAction("Index");

        }
    }
}
