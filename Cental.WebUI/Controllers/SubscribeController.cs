using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class SubscribeController(ISubscribeService _subscribeService) : Controller
    {


        public IActionResult Subscribe(Subscribe newSubscribe)
        {
            var subscribeList = _subscribeService.TGetAll();

            if (subscribeList.Any(x => x.Email == newSubscribe.Email))
            {
                TempData["SubscribeError"] = "Zaten Abonesiniz Tekrar Abone Olamazsınız!";
                return RedirectToAction("Index", "Default");
            }

            else if (string.IsNullOrEmpty(newSubscribe.Email))
            {
                TempData["SubscribeNullError"] = "Lütfen Mail Girin";
                return RedirectToAction("Index", "Default");
            }



            else
            {
                _subscribeService.TCreate(newSubscribe);
                return RedirectToAction("Index", "Default");
            }

        }
    }
}
