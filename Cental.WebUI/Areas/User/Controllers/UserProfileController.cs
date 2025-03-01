using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserProfileController(UserManager<AppUser> _userManager, IMapper _mapper, IImageService _imageService) : Controller
    {


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var profileEditDto = _mapper.Map<ProfileEditDto>(user);



            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }



            return View(profileEditDto);
        }

        [HttpPost]

        public async Task<IActionResult> Index(ProfileEditDto UpdateUser)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var IsPassword = await _userManager.CheckPasswordAsync(user, UpdateUser.CurrentPassword);


            if (IsPassword)
            {
                if (UpdateUser.ImageFile != null)
                {
                    try
                    {
                        UpdateUser.ImageUrl = await _imageService.SaveImageAsync(UpdateUser.ImageFile, "userImage");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("WrongType", ex.Message);
                        var error = ModelState["WrongType"].Errors[0].ErrorMessage;
                        ViewBag.WrongType = error;

                    }
                }

                user.FirstName = UpdateUser.FirstName;
                user.LastName = UpdateUser.LastName;
                user.Email = UpdateUser.Email;
                user.PhoneNumber = UpdateUser.PhoneNumber;
                user.ProfilePicture = UpdateUser.ImageUrl;


                _mapper.Map<AppUser>(user);

                var result = await _userManager.UpdateAsync(user);


                if (result.Succeeded)
                {
                    TempData["Success"] = "Bilgileriniz Başarıyla Güncellendi!";
                    return RedirectToAction("Index", "UserProfile");
                }

                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(UpdateUser);
                }
            }
            else
            {
                ModelState.AddModelError("WrongPassword", "Girdiğiniz şifre hatalı güncelleme yapılamadı!");
                var error = ModelState["WrongPassword"].Errors[0].ErrorMessage;
                ViewBag.WrongPassword = error;
                return View(UpdateUser);
            }



        }
    }
}
