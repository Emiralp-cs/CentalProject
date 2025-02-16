using AutoMapper;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _UIManagerComponent(UserManager<AppUser> _userManager,IMapper _mapper) : ViewComponent
    {   

        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var managers = await _userManager.GetUsersInRoleAsync("Manager");

            var dto = _mapper.Map<IList<ResultUserDto>>(managers);

            return View(dto.TakeLast(4).ToList());
        }
    }
}
