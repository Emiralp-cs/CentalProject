using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]

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

            var profileEditDto = _mapper.Map<ProfileEditDto>(user);

            return View(profileEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileEditDto UpdateAdmin)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            var IsPassword = await _userManager.CheckPasswordAsync(user, UpdateAdmin.CurrentPassword);

            if (IsPassword)
            {
                if (UpdateAdmin.ImageFile != null)
                {
                    try
                    {
                        UpdateAdmin.ImageUrl = await _imageService.SaveImageAsync(UpdateAdmin.ImageFile, "adminImage");
                    }
                    catch (Exception ex)
                    {

                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(UpdateAdmin);
                    }
                }


                user.FirstName = UpdateAdmin.FirstName;
                user.LastName = UpdateAdmin.LastName;
                user.Email = UpdateAdmin.Email;
                user.PhoneNumber = UpdateAdmin.PhoneNumber;
                user.ProfilePicture = UpdateAdmin.ImageUrl;


                var result = await _userManager.UpdateAsync(user);


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
            else
            {
                ModelState.AddModelError(string.Empty, "Girdiğiniz şifre hatalı güncelleme yapılamadı!");
                return View(UpdateAdmin);
            }


        }
    }
}
