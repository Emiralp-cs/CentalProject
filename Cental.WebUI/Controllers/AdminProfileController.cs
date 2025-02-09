using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminProfileController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        private readonly IMapper _mapper;

        private readonly IImageService _imageService;

        public AdminProfileController(UserManager<AppUser> userManager, IMapper mapper, IImageService imageService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var profileEditDto = _mapper.Map<ProfileEditDto>(User);

            return View(profileEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileEditDto UpdateAdmin)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            var IsPassword = await _userManager.CheckPasswordAsync(user, UpdateAdmin.CurrentPassword);

            if (IsPassword)
            {
                if (UpdateAdmin.AdminProfileImageFile != null)
                {
                    UpdateAdmin.AdminProfileImageUrl = await _imageService.SaveImageAsync(UpdateAdmin.AdminProfileImageFile);
                }


                var updateUser = _mapper.Map<AppUser>(UpdateAdmin);


                var result = await _userManager.UpdateAsync(updateUser);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "AdminProfile");
                }


                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(UpdateAdmin);
                }
            }

            ModelState.AddModelError(string.Empty, "Girdiğiniz şifre hatalı güncelleme yapılamadı");
            return View(UpdateAdmin);

        }
    }
}
