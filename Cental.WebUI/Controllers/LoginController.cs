using AutoMapper;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        private readonly IMapper _mapper;


        public LoginController(SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto registeredUser,string? returnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(registeredUser.UserName, registeredUser.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(registeredUser);
            }

            if (returnUrl != null) 
            {
                return Redirect(returnUrl);
            }


            return RedirectToAction("Index", "AdminAbout");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }

    }
}
