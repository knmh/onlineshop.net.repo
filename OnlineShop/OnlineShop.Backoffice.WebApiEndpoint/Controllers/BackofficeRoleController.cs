using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Application.Services.AAAServices;

namespace OnlineShop.Backoffice.WebApiEndpoint.Controllers
{
    public class BackofficeRoleController : Controller
    {
        private readonly RoleService _roleService;

        public BackofficeRoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var roles = _roleService.GetAllRolesAsync().Result; 
            return View(roles);
        }

        [Authorize]
        public IActionResult RegisterRole()
        {
            return View(new CreateRoleAppDto());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRole(CreateRoleAppDto createRoleModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.CreateRoleAsync(createRoleModel.RoleName); 
                if (result.Succeeded)
                {
                    TempData["Message"] = "Role Created";
                    return RedirectToAction("Index", "Role");
                }
                else
                {
                    foreach (var e in result.Errors)
                    {
                        ModelState.AddModelError("", e.Description);
                    }
                }
            }
            return View(createRoleModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (result.Succeeded)
            {
                TempData["Message"] = "Role is Deleted";
            }
            else
            {
                TempData["Message"] = "Fail Delete";
            }
            return RedirectToAction("Index", "Role");
        }
    }

}

