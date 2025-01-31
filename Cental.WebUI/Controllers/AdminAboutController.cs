using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.TGetAll();

            var result = values.Select(about => new ToListAboutDto
            {   
                AboutId = about.AboutId,
                Description1 = about.Description1,
                Description2 = about.Description2,
                ImageUrl1 = about.ImageUrl1,
                ImageUrl2 = about.ImageUrl2,
                Item1 = about.Item1,
                Item2 = about.Item2,
                Item3 = about.Item3,
                Item4 = about.Item4,
                JobTitle = about.JobTitle,
                NameSurname = about.NameSurname,
                Mission = about.Mission,
                ProfilePicture = about.ProfilePicture,
                StartYear = about.StartYear,
                Vision = about.Vision
            }).ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            var check = _aboutService.TGetAll().Count;

            if (check == 1)
            {
                TempData["CountError"] = "En Fazla 1 tane hakkımda bulunabilir.";
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }


            
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto newAbout)
        {



            //Manuel olarak object to object mapping
            _aboutService.TCreate(new About
            {
                Description1 = newAbout.Description1,
                Description2 = newAbout.Description2,
                ImageUrl1 = newAbout.ImageUrl1,
                ImageUrl2 = newAbout.ImageUrl2,
                Item1 = newAbout.Item1,
                Item2 = newAbout.Item2,
                Item3 = newAbout.Item3,
                Item4 = newAbout.Item4,
                JobTitle = newAbout.JobTitle,
                Mission = newAbout.Mission,
                NameSurname = newAbout.NameSurname,
                ProfilePicture = newAbout.ProfilePicture,
                StartYear = newAbout.StartYear,
                Vision = newAbout.Vision
            });
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {

            _aboutService.TDelete(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about = _aboutService.TGetById(id);
            var DtoAbout = new UpdateAboutDto
            {
                AboutId = about.AboutId,
                Description1 = about.Description1,
                Description2 = about.Description2,
                ImageUrl1 = about.ImageUrl1,
                ImageUrl2 = about.ImageUrl2,
                Item1 = about.Item1,
                Item2 = about.Item2,
                Item3 = about.Item3,
                Item4 = about.Item4,
                JobTitle = about.JobTitle,
                NameSurname = about.NameSurname,
                Mission = about.Mission,
                ProfilePicture = about.ProfilePicture,
                StartYear = about.StartYear,
                Vision = about.Vision
            };


            return View(DtoAbout);
        }
        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto updateAbout)
        {
            var about = new About
            {
                AboutId = updateAbout.AboutId,
                Description1 = updateAbout.Description1,
                Description2 = updateAbout.Description2,
                ImageUrl1 = updateAbout.ImageUrl1,
                ImageUrl2 = updateAbout.ImageUrl2,
                Item1 = updateAbout.Item1,
                Item2 = updateAbout.Item2,
                Item3 = updateAbout.Item3,
                Item4 = updateAbout.Item4,
                JobTitle = updateAbout.JobTitle,
                Mission = updateAbout.Mission,
                NameSurname = updateAbout.NameSurname,
                ProfilePicture = updateAbout.ProfilePicture,
                StartYear = updateAbout.StartYear,
                Vision = updateAbout.Vision
            };

            _aboutService.TUpdate(about);

            return RedirectToAction("Index");

        }
    }
}
