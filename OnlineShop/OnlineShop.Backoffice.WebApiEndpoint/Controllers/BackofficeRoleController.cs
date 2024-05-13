using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Application.Services.AAAServices;

namespace OnlineShop.Backoffice.WebApiEndpoint.Controllers
{
    [Authorize]
    [Route("api/BackofficeRole")]
    [ApiController]
    public class BackofficeRoleController : ControllerBase
    {
        #region [Private State] 
        private readonly RoleService _roleService;
        #endregion

        #region [Ctor]
        public BackofficeRoleController(RoleService roleService)
        {
            _roleService = roleService;
        }
        #endregion

        #region [GetAllRoles()]
        [HttpGet("getAllRoles", Name = "GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }
        #endregion
        //[Authorize]
        //[HttpGet("register", Name = "RegisterRole")]
        //public IActionResult RegisterRole()
        //{
        //    return Ok(new CreateRoleAppDto());
        //}
        #region [RegisterRole(CreateRoleAppDto createRoleModel)]
        [HttpPost("register", Name = "RegisterRole")]
        public async Task<IActionResult> RegisterRole(CreateRoleAppDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.CreateRoleAsync(model);
                if (result.Succeeded)
                {
                    return Ok(new { message = "Role Created" });
                }
                else
                {
                    return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
                }
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region [Delete(DeleteRoleAppDto model)]
        [HttpDelete(Name = "Delete")]
        public async Task<IActionResult> Delete(DeleteRoleAppDto model)
        {
            var result = await _roleService.DeleteRoleAsync(model);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role is Deleted" });
            }
            else
            {
                return BadRequest(new { message = "Fail Delete" });
            }
        }
        #endregion
        #region [UpdateRole(UpdateRoleAppDto model)]
        [HttpPut("update", Name = "UpdateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleAppDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.UpdateRoleAsync(model);
                if (result.Succeeded)
                {
                    return Ok(new { message = "Role Updated" });
                }
                else
                {
                    return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
                }
            }
            return BadRequest(ModelState);
        }
        #endregion
    }
}

