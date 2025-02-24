using AutoMapper;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUpUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpUser(UserRegisterDto newUser)
        {
            var user = _mapper.Map<AppUser>(newUser);

            if (!ModelState.IsValid)
            {
                return View(newUser);

            }
            //küçük harf , büyük harf , rakam , özel karakter en az 6 karakter olmalı
            var result = await _userManager.CreateAsync(user, newUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(newUser);
            }

            await _userManager.AddToRoleAsync(user, "User");

            return RedirectToAction("SignIn", "Login");

        }

        [HttpGet]
        public IActionResult SignUpManager()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignUpManager(UserRegisterDto newUser)
        {
            var user = _mapper.Map<AppUser>(newUser);

            if (!ModelState.IsValid)
            {
                return View(newUser);

            }
            //küçük harf , büyük harf , rakam , özel karakter en az 6 karakter olmalı
            var result = await _userManager.CreateAsync(user, newUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(newUser);
            }

            await _userManager.AddToRoleAsync(user, "Manager");
            return RedirectToAction("SignIn", "Login");

        }
    }
}
