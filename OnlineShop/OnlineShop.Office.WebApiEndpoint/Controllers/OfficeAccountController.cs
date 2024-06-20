using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Application.Dtos.SaleDtos.AccountAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Application.Services.SaleServices;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    public class OfficeAccountController : ControllerBase
    {
        
        #region [Private State] 
        private readonly AccountService _accountService;
        #endregion

        #region [Ctor]
        public OfficeAccountController(AccountService accountService)
        {
            _accountService = accountService;
           
        }
        #endregion
        #region [SignIn([FromBody] SignInAppDto model)]
        [HttpPost("signIn", Name = "SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInAppDto model)
        {
            var response = await _accountService.SignInAsync(model);
            if (response != null)
            {
                return Ok(response);
            }
            return Unauthorized();
        }
        #endregion
        #region [SignOut()]
        [Authorize]
        [HttpPost("signOut", Name = "SignOut")]
        public async Task<IActionResult> SignOut()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            _accountService.SignOutAsync(token);
            return Ok();
        } 
        #endregion

    }
}
