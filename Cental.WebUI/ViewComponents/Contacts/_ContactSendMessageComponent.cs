using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Contacts
{
    public class _ContactSendMessageComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Contact model)
        {
            return View(model);
        }
    }
}
