using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Application.Services.AAAServices;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;

namespace OnlineShop.Backoffice.WebApiEndpoint.Controllers
{
    [Route("api/BackofficeUser")]

    public class BackofficeUserController : Controller
    {
        #region [Private State] 
       
        private readonly UserService _userService;
        #endregion

        #region [Ctor]
        public BackofficeUserController(UserService userService)
        {
            _userService = userService;
        }
        #endregion
        #region [Index()]
        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }
        #endregion

        #region [RegisterUser()]
        public IActionResult RegisterUser()
        {

            return View();
        } 
        #endregion

        #region [RegisterUser(CreateUserAppDto model)]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserAppDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result.Succeeded)
                {
                    TempData["Message"] = "User Created";
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        #endregion


        #region [Delete(string id)]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result)
            {
                TempData["Message"] = "User is Deleted";
            }
            else
            {
                TempData["Message"] = "Failed to delete user";
            }
            return RedirectToAction("Index", "Users");
        }
        #endregion

        #region [EditUserRoles(EditUserRolesAppDto model)]
        public async Task<IActionResult> EditUserRoles(EditUserRolesAppDto model)
        {
            var editUserRoles = await _userService.GetEditUserRolesViewModelAsync(model);
            return View(editUserRoles);
        }
        #endregion


        //#region [EditUserRoles(string userId, List<string> roles)]
        //[HttpPost]
        //public async Task<IActionResult> EditUserRoles(string userId, List<string> roles)
        //{
        //    var user = await _userService.GetUserByIdAsync(userId); // Assuming GetUserByIdAsync is a method in your UserService
        //    var currentRoles = await _userService.UserManager.GetRolesAsync(user);

        //    foreach (var item in currentRoles)
        //    {
        //        if (!roles.Contains(item))
        //        {
        //            await _userService.UserManager.RemoveFromRoleAsync(user, item);
        //        }
        //    }

        //    foreach (var item in roles)
        //    {
        //        var isInRole = await _userService.UserManager.IsInRoleAsync(user, item);
        //        if (!isInRole)
        //        {
        //            await _userService.UserManager.AddToRoleAsync(user, item);
        //        }
        //    }

        //    return RedirectToAction("Index", "User");
        //}
        //#endregion
        //[HttpPost]
        //public async Task<IActionResult> EditUserRoles(EditUserRolesAppDto model)
        //{
        //    var user = await _userManager.FindByIdAsync(model.UserId);
        //    if (user == null)
        //    {
        //        // Handle the case where the user is not found
        //        return NotFound();
        //    }

        //    var currentRoles = await _userManager.GetRolesAsync(user);

        //    foreach (var item in currentRoles)
        //    {
        //        if (!model.UserRoles.Contains(item))
        //        {
        //            var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, item);
        //            if (!removeRoleResult.Succeeded)
        //            {
        //                // Handle the case where removing a role failed
        //                return BadRequest();
        //            }
        //        }
        //    }

        //    foreach (var item in model.Roles)
        //    {
        //        var isInRole = await _userManager.IsInRoleAsync(user, item.Name);
        //        if (!isInRole)
        //        {
        //            var addToRoleResult = await _userManager.AddToRoleAsync(user, item.Name);
        //            if (!addToRoleResult.Succeeded)
        //            {
        //                // Handle the case where adding a role failed
        //                return BadRequest();
        //            }
        //        }
        //    }

        //    return RedirectToAction("Index", "User");
        //}

    }
}
    

