using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController(IContactService _contactService) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ActivePage = "Contact";
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact newContact)
        {

            if (string.IsNullOrEmpty(newContact.NameSurname) || string.IsNullOrEmpty(newContact.Email) || string.IsNullOrEmpty(newContact.Subject) || string.IsNullOrEmpty(newContact.Message))
            {

                if (string.IsNullOrEmpty(newContact.NameSurname))
                {
                    TempData["NameSurnameNullError"] = "Ad Soyad Boş Bırakılamaz!";
                }

                if (string.IsNullOrEmpty(newContact.Email))
                {
                    TempData["EmailNullError"] = "E-Posta Boş Bırakılamaz!";
                }

                if (string.IsNullOrEmpty(newContact.Subject))
                {
                    TempData["SubjectNullError"] = "Konu Boş Bırakılamaz!";
                }

                if (string.IsNullOrEmpty(newContact.Message))
                {
                    TempData["MessageNullError"] = "Mesaj Boş Bırakılamaz!";
                }

                TempData["NameSurname"] = newContact.NameSurname;
                TempData["Email"] = newContact.Email;
                TempData["Subject"] = newContact.Subject;
                TempData["Message"] = newContact.Message;


                return RedirectToAction("Index");
            }

            else
            {   

                newContact.Isreaded = false;

                _contactService.TCreate(newContact);

                return RedirectToAction("Index");
            }

        }
    }
}
