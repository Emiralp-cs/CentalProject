using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Extensions.Enums;
using Cental.DataAccessLayer.Concrate;
using Cental.DTOLayer.CarDtos;
using Cental.DTOLayer.Enums;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminCarController : Controller
    {
        private readonly IBrandService _brandService;

        private readonly ICarService _carService;

        private readonly IMapper _mapper;

        private readonly IImageService _imageService;

        private readonly RoleManager<AppRole> _roleManager;

        private readonly UserManager<AppUser> _userManager;

        public AdminCarController(IBrandService brandService, ICarService carService, IMapper mapper, IImageService imageService, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _brandService = brandService;
            _carService = carService;
            _mapper = mapper;
            _imageService = imageService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var result = _carService.TListN();

            return View(result);
        }

        [HttpGet]
        public IActionResult CreateCar()
        {

            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
            ViewBag.transmissionTypes = GetEnumValues.GetEnums<TransmissionTypes>();
            ViewBag.brands = (from x in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text = x.BrandName,
                                  Value = x.BrandId.ToString()

                              }).ToList();

            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> CreateCar(CreateCarDto NewCar)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var role = await _roleManager.FindByNameAsync("Admin");

            if (NewCar.ImageFile != null)
            {
                try
                {
                    NewCar.ImageUrl = await _imageService.SaveImageAsync(NewCar.ImageFile, "CreateCarImage");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("WrongType", ex.Message);
                    var error = ModelState["WrongType"].Errors[0].ErrorMessage;
                    ViewBag.WrongType = error;
                }
            }


            if (!ModelState.IsValid)
            {

                ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
                ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
                ViewBag.transmissionTypes = GetEnumValues.GetEnums<TransmissionTypes>();
                ViewBag.brands = (from x in _brandService.TGetAll()
                                  select new SelectListItem
                                  {
                                      Text = x.BrandName,
                                      Value = x.BrandId.ToString()

                                  }).ToList();
                return View(NewCar);
            }
            NewCar.UserId = user.Id;
            NewCar.RoleId = role.Id;
            _carService.TCreateN(NewCar);

            return RedirectToAction("Index");
        }


        public IActionResult DeleteCar(int id)
        {
            _carService.TDelete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCar(int id)
        {
            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
            ViewBag.transmissionTypes = GetEnumValues.GetEnums<TransmissionTypes>();
            ViewBag.brands = (from x in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text = x.BrandName,
                                  Value = x.BrandId.ToString()

                              }).ToList();
            return View(_carService.TUpdate_GetN(id));
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto UpdateCar)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var role = await _roleManager.FindByNameAsync("Admin");
            if (UpdateCar.ImageFile != null)
            {
                try
                {
                    UpdateCar.ImageUrl = await _imageService.SaveImageAsync(UpdateCar.ImageFile, "CreateCarImage");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("WrongType", ex.Message);
                    var error = ModelState["WrongType"].Errors[0].ErrorMessage;
                    ViewBag.WrongType = error;
                }
            }


            if (!ModelState.IsValid)
            {
                ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
                ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
                ViewBag.transmissionTypes = GetEnumValues.GetEnums<TransmissionTypes>();
                ViewBag.brands = (from x in _brandService.TGetAll()
                                  select new SelectListItem
                                  {
                                      Text = x.BrandName,
                                      Value = x.BrandId.ToString()

                                  }).ToList();
                return View(UpdateCar);



            }
            UpdateCar.UserId = user.Id;
            UpdateCar.RoleId = role.Id;
            _carService.T_Update_PostN(UpdateCar);

            return RedirectToAction("Index");

        }
    }
}
