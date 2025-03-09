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
    public class MySocialController(IUserSocialService _userSocialService, UserManager<AppUser> _userManager, IMapper _mapper) : Controller
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
        public async Task<IActionResult> CreateSocial(CreateUserSocialDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            model.UserId = user.Id;
            _userSocialService.TCreateN(model);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteSocial(int id)
        {
            _userSocialService.TDelete(id);
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult UpdateSocial(int id)
        {

            var currentSocial = _userSocialService.TUpdate_GetN(id);

            return View(currentSocial);
        }

        [HttpPost]
        public  async Task<IActionResult> UpdateSocial(UpdateUserSocialDto model)
        {   

            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            model.User = currentUser;


            if (!ModelState.IsValid)
            {
                
                return View(model);
            }




            _userSocialService.T_Update_PostN(model);
            return RedirectToAction("Index");
        }
    }
}
