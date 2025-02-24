using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{

    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ManagerProfileController(UserManager<AppUser> _userManager, IMapper _mapper, IImageService _imageService) : Controller
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

        public async Task<IActionResult> Index(ProfileEditDto UpdateManager)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var IsPassword = await _userManager.CheckPasswordAsync(user, UpdateManager.CurrentPassword);


            if (IsPassword)
            {
                if (UpdateManager.ImageFile != null)
                {
                    try
                    {
                        UpdateManager.ImageUrl = await _imageService.SaveImageAsync(UpdateManager.ImageFile, "managerImage");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("WrongType", ex.Message);
                        var error = ModelState["WrongType"].Errors[0].ErrorMessage;
                        ViewBag.WrongType = error;

                    }
                }

                user.FirstName = UpdateManager.FirstName;
                user.LastName = UpdateManager.LastName;
                user.Email = UpdateManager.Email;
                user.PhoneNumber = UpdateManager.PhoneNumber;
                user.ProfilePicture = UpdateManager.ImageUrl;


                var result = await _userManager.UpdateAsync(user);


                if (result.Succeeded)
                {
                    TempData["Success"] = "Bilgileriniz Başarıyla Güncellendi!";
                    return RedirectToAction("Index", "ManagerProfile");
                }

                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(UpdateManager);
                }
            }
            else
            {
                ModelState.AddModelError("WrongPassword", "Girdiğiniz şifre hatalı güncelleme yapılamadı!");
                var error = ModelState["WrongPassword"].Errors[0].ErrorMessage;
                ViewBag.WrongPassword = error;
                return View(UpdateManager);
            }



        }



    }


}
