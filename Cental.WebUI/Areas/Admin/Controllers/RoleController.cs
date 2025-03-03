using AutoMapper;
using Cental.DTOLayer.RoleDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {

        private readonly RoleManager<AppRole> _roleManager;

        private readonly IMapper _mapper;

        public RoleController(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();

            var resultdto = _mapper.Map<List<ResultRoleDto>>(roles);

            return View(resultdto);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto newRole)
        {
            var role = _mapper.Map<AppRole>(newRole);

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View(newRole);
                }
            }


            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            var updateDto = _mapper.Map<UpdateRoleDto>(role);

            return View(updateDto);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRole)
        {
            var role = _mapper.Map<AppRole>(updateRole);
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View(updateRole);
                }
            }

            return RedirectToAction("Index");

        }

    }
}
