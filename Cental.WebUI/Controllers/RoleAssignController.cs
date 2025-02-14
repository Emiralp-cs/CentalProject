using AutoMapper;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RoleAssignController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        private readonly UserManager<AppUser> _userManager;

        private readonly IMapper _mapper;

        public RoleAssignController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var userdto = new List<ResultUserDto>();

            foreach (var user in users)
            {
                var resultdto = new ResultUserDto
                {
                    Roles = await _userManager.GetRolesAsync(user),
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email

                };
                 
                userdto.Add(resultdto);

            }

            return View(userdto);
        }


        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            var assignRoleDtoList = new List<AssignRoleDto>();

            ViewBag.fullname = string.Join(" ", user.FirstName, user.LastName);

            foreach (var item in roles)
            {
                var model = new AssignRoleDto
                {
                    UserId = user.Id,
                    RoleName = item.Name,
                    RoleId = item.Id,
                    RoleExist = userRoles.Contains(item.Name)

                };
                assignRoleDtoList.Add(model);
            }

            return View(assignRoleDtoList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> AssignRole)
        {
            var userId = AssignRole.Select(x => x.UserId).FirstOrDefault();


            var user = await _userManager.FindByIdAsync(userId.ToString());


            foreach (var item in AssignRole)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
