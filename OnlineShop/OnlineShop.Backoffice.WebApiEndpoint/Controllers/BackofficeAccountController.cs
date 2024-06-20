using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Application.Services.AAAServices;
using OnlineShop.Application.Services.Contracts.IService;

namespace OnlineShop.Backoffice.WebApiEndpoint.Controllers
{
    [Route("api/BackofficeAccount")]
    [ApiController]
    public class BackofficeAccountController : Controller
    {
        #region [Private State] 
        private readonly AccountService _accountService;
        private readonly ILogger<AccountService> _logger;
        #endregion

        #region [Ctor]
        public BackofficeAccountController(AccountService accountService, ILogger<AccountService> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }
        #endregion


        #region [ Login(LoginAppDto model)]
        [HttpPost("login", Name = "Login")]
        public async Task<IActionResult> Login([FromBody] LoginAppDto model)
        {
            var response = await _accountService.LoginAsync(model);
            if (response != null)
            {
                return Ok(response);
            }
            return Unauthorized();
        }
        #endregion

        #region [Logout()]

        //public async Task<IActionResult> Logout()
        //{
        //    string authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();

        //    if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
        //    {
        //        return BadRequest("Token is missing or invalid.");
        //    }

        //    string token = authorizationHeader.Substring("Bearer ".Length);

        //    try
        //    {
        //        await _accountService.LogoutAsync(token);
        //        return Ok("User logged out successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error logging out: {ex.Message}");
        //        return StatusCode(500, "An error occurred while logging out.");
        //    }
            //}
            [Authorize]
            [HttpPost("logout", Name = "Logout")]
            public async Task<IActionResult> LogoutAsync()
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                _accountService.ExpireToken(token);
                return Ok();
            }
            #endregion
        }
}

