using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Application.Services.AAAServices;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System.Data;

namespace OnlineShop.Backoffice.WebApiEndpoint.Controllers
{
    [Authorize]
    [Route("api/BackofficeUser")]
    [ApiController]
    public class BackofficeUserController : ControllerBase
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

        [HttpGet]
        public async Task<IActionResult> GetAllUsersWithRoles()
        {
            var users = await _userService.GetAllUsersWithRolesAsync();
            return Ok(users);
        }

        //[HttpGet("{userId}")]
        //public async Task<IActionResult> GetUserWithRoles(string userId)
        //{
        //    var user = await _userService.GetUserWithRolesAsync(userId);
        //    if (user == null)
        //        return NotFound();

        //    return Ok(user);
        //}

        //[HttpGet("register")]
        //#region [RegisterUser()]
        //public IActionResult RegisterUser()
        //{
        //    return Ok(new CreateUserAppDto());

        //}
        //#endregion
        #region [RegisterUser(CreateUserAppDto model)]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(CreateUserAppDto model)
        {
            if (ModelState.IsValid)
            {
              
                var result = await _userService.RegisterUserAsync(model);
                if (result.Succeeded)
                {
                    return Ok(new { message = ",User Created" });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
                    }
                }
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region [Delete(DeleteUserAppDto model)]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserAppDto model)
        {
            var result = await _userService.DeleteUserAsync(model);
            if (result)
            {
                return Ok(new { message = "User is Deleted" });
            }
            else
            {
                return BadRequest(new { message = "Fail Delete" });
            }
          
        }
        #endregion
        #region [EditUserRoles(EditUserRolesAppDto model)]
        [HttpPut("editUserRoles")]
        public async Task<IActionResult> EditUserRoles(EditUserRolesAppDto model)
        {
            var editUserRoles = await _userService.UpdateUserRolesAsync(model);
            return Ok(editUserRoles);
        }
        #endregion


     
      
    }
}


