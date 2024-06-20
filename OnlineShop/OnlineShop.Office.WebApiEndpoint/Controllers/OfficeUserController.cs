using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.SaleDtos.AccountAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.UserAppDtos;
using OnlineShop.Application.Services.AAAServices;
using OnlineShop.Application.Services.SaleServices;
using UserService = OnlineShop.Application.Services.SaleServices.UserService;

namespace OnlineShop.Office.WebApiEndpoint.Controllers
{
    public class OfficeUserController : ControllerBase
    {
        #region [Private State] 
        private readonly UserService _userService;
        #endregion

        #region [Ctor]
        public OfficeUserController(UserService userService)
        {
            _userService = userService;
        }
        #endregion
         
        #region [SignUp([FromBody] SignUpAppDto model)]
        [HttpPost("signUpAppDto", Name = "SignUpAppDto")]
        public async Task<IActionResult> SignUp([FromBody] SignUpAppDto model)
        {
            var response = await _userService.SignUpAsync(model);
            if (response != null)
            {
                return Ok(response);
            }
            return Unauthorized();
        }
        #endregion

    }




}
