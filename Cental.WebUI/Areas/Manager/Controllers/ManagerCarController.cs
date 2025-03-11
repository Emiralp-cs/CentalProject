using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Extensions.Enums;
using Cental.DTOLayer.CarDtos;
using Cental.DTOLayer.Enums;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.Manager.Controllers
{

    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ManagerCarController(ICarService _carService, IBrandService _brandService, RoleManager<AppRole> _roleManager, UserManager<AppUser> _userManager, IImageService _imageService, IBookingService _bookingService, IReviewService _reviewService) : Controller
    {
        public async Task<IActionResult> Index()
        {

            var result = _carService.TGetAll();
            var manager_User = await _userManager.FindByNameAsync(User.Identity.Name);

            var ManagerId = manager_User.Id;
            var filterResult = result.Where(x => x.RoleId == 2 && x.UserId == ManagerId).ToList();

            var rentedCars = _bookingService.TGetAll();

            if (filterResult.Count == 0)
            {
                TempData["ZeroError"] = "Henüz Bir Aracınız Bulunmuyor";
                return View();
            }
            int count = 0;
            int count1 = 0;
            foreach (var item in filterResult)
            {
                var rented_cars = rentedCars.Where(x => x.CarId == item.CarId).ToList();

                foreach (var rented in rented_cars)
                {
                    if (rented.IsApproved == true)
                    {
                        count1++;
                        var rentedUser = await _userManager.FindByIdAsync(rented.UserId.ToString());
                        var rentedUserName = string.Join(" ", rentedUser.FirstName, rentedUser.LastName);
                        TempData[count1.ToString()] = rentedUserName;
                    }

                }
                count = count1;
                count++;
                TempData[count1.ToString() + "1"] = "Kiralanmadı";
                TempData[count.ToString()] = "Henüz Kiralanmadı";

            }

            return View(filterResult);

        }


        [HttpGet]
        public async Task<IActionResult> VehicleDetails(int Id)
        {


            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var managerCarList = _carService.TGetAll().Where(x => x.UserId == user.Id && x.RoleId == 2);

            var result = managerCarList.Where(x => x.CarId == Id).FirstOrDefault();

            return View(result);



        }

        [HttpGet]
        public IActionResult RentState(int Id)
        {

            var BookingCar = _bookingService.TGetAll().Where(x => x.CarId == Id).ToList();

            int count = 0;


            if (BookingCar.Count != 0)
            {
                foreach (var car in BookingCar)
                {
                    count++;
                    if (car.IsApproved == null)
                    {
                        TempData[count.ToString()] = "Onay Bekliyor";
                    }

                    else if (car.IsApproved == true)
                    {
                        TempData[count.ToString()] = "Onaylandı";
                    }

                    else if (car.IsApproved == false)
                    {
                        TempData[count.ToString()] = "Reddedildi";
                    }
                }




                return View(BookingCar);
            }

            else
            {
                TempData["BookingCarNullError"] = "Henüz Bu Aracınız Kiralanmadı";
                return View();
            }


        }



        public IActionResult RentStateApply(string id, string userId)
        {
            var car = _carService.TGetAll().Where(x => x.CarId == int.Parse(id)).FirstOrDefault();

            var Bookcar = _bookingService.TGetAll().Where(x => x.CarId == int.Parse(id) && x.UserId == int.Parse(userId)).FirstOrDefault();

            if (car.IsApproved == true)
            {
                TempData["ApplyError"] = "Bu Aracı Zaten Kiralaması İçin Onayladınız";
                return RedirectToAction("RentState", new { id = id });
            }





            car.IsApproved = true;

            var DeclineBookingList = _bookingService.TGetAll().Where(x => x.CarId == int.Parse(id) && x.IsApproved != true).ToList();

            foreach (var item in DeclineBookingList)
            {
                item.IsApproved = false;
                _bookingService.TUpdate(item);
            }
            _carService.TUpdate(car);
            Bookcar.IsApproved = true;
            _bookingService.TUpdate(Bookcar);

            return RedirectToAction("Index");
        }

        public IActionResult RentStateDecline(string id, string userId)
        {

            var Bookcar = _bookingService.TGetAll().Where(x => x.CarId == int.Parse(id) && x.UserId == int.Parse(userId)).FirstOrDefault();

            var car = _carService.TGetAll().Where(x => x.CarId == int.Parse(id)).FirstOrDefault();

            if (car.IsApproved == true && Bookcar.IsApproved == true)
            {

                car.IsApproved = false;
                Bookcar.IsApproved = false;
                _bookingService.TUpdate(Bookcar);
                _carService.TUpdate(car);
                return RedirectToAction("Index");

            }

            if (car.IsApproved == true)
            {
                TempData["DeclineError"] = "Bu Araç Otomatik Olarak Reddedildi Olarak İşaretlendi";
                return RedirectToAction("RentState", new { id = id });
            }

            Bookcar.IsApproved = false;
            car.IsApproved = false;

            _bookingService.TUpdate(Bookcar);


            return RedirectToAction("Index");

        }


        public IActionResult RentStateNull(string id, string userId)
        {
            var Bookcar = _bookingService.TGetAll().Where(x => x.CarId == int.Parse(id) && x.UserId == int.Parse(userId)).FirstOrDefault();

            var car = _carService.TGetAll().Where(x => x.CarId == int.Parse(id)).FirstOrDefault();


            if (car.IsApproved == true && Bookcar.IsApproved == true)
            {

                car.IsApproved = null;
                Bookcar.IsApproved = null;
                _bookingService.TUpdate(Bookcar);
                _carService.TUpdate(car);
                return RedirectToAction("Index");


            }

            if (car.IsApproved == true)
            {
                TempData["RentStateNullError1"] = "Araç Kiralandığı İçin Sadece Reddedildi Olarak Kalabilir!";
                return RedirectToAction("RentState", new { id = id });
            }

            Bookcar.IsApproved = null;
            _bookingService.TUpdate(Bookcar);
            return RedirectToAction("Index");


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

            var role = await _roleManager.FindByNameAsync("Manager");

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
            var bookingList = _bookingService.TGetAll();

            if (bookingList.Where(x => x.CarId == id).Any())
            {

                TempData["RentedCarError"] = "Bu Aracı Silemezsiniz Çünkü Şu Anda Kiralanmış Durumda!";

                return RedirectToAction("Index");
            }

            else
            {
                _carService.TDelete(id);
            }

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

            var role = await _roleManager.FindByNameAsync("Manager");
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

        public IActionResult CarReviews(int Id)
        {
            var Reviews = _reviewService.TGetAll().Where(x => x.CarId == Id).ToList();

            //O arabaya ait gelen bütün yorumlar gelecek ancak kullanıcını id sine göre filtreme yapılacak

            if (Reviews.Count == 0)
            {
                TempData["ReviewsCountError"] = "Henüz Bu Aracınıza Yorum Yapılmamıştır";
                return View();
            }




            return View(Reviews);
        }


    }
}
