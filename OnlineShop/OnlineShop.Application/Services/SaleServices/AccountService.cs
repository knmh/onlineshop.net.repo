using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Application.Dtos.SaleDtos.AccountAppDtos;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.SaleServices
{
    public class AccountService
    {

        #region [Private State] 
        private readonly UserManager<OnlineShopUser> _userManager;
        private readonly SignInManager<OnlineShopUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountService> _logger;

        #endregion

        #region [Ctor]
        public AccountService(UserManager<OnlineShopUser> userManager, SignInManager<OnlineShopUser> signInManager, IConfiguration configuration, ILogger<AccountService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
        }
        #endregion

        #region [SignInAsync(SignInAppDto model)]
        public async Task<AuthenticateResponseAppDto> SignInAsync(SignInAppDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Handle the case where the user is not found
                return null;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                // Record the sign-in time
                user.LastSignInTime = DateTime.UtcNow;

                // Save the user entity to the database
                await _userManager.UpdateAsync(user);

                var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

                // Generate a token
                var token = GenerateToken(authClaims, user.Id);

                // Return the token or perform other actions
                return new AuthenticateResponseAppDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }

            // Handle unsuccessful sign-in
            return null;
        }
        #endregion
        #region [GenerateToken(List<Claim> authClaims)]
        private JwtSecurityToken GenerateToken(List<Claim> authClaims, string userId)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.UtcNow.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
        #endregion

        #region [SignOutAsync(string token)]
        public async Task SignOutAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken != null)
            {
                string audience = jwtToken.Audiences.FirstOrDefault();
             
                var newToken = new JwtSecurityToken(
                    jwtToken.Issuer,
                    audience,
                    jwtToken.Claims,
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    jwtToken.SigningCredentials
                );
                token = new JwtSecurityTokenHandler().WriteToken(newToken);
            }
        }
        #endregion

       
        #region [IsTokenValidAsync(string token)]
        public async Task<bool> IsTokenValidAsync(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    // Assuming _configuration["JWT:Audience"] is a single string value
                    ValidAudiences = new[] { _configuration["JWT:Audience"] }, // Use this if you have a single audience
                                                                               // If you have multiple audiences, you can add them like this:
                                                                               // ValidAudiences = new[] { "audience1", "audience2", "audience3" },
                    ClockSkew = TimeSpan.Zero
                };

                // If the audience configuration is empty or not set, this will prevent the exception
                if (string.IsNullOrEmpty(validationParameters.ValidAudiences.FirstOrDefault()))
                {
                    throw new Exception("The 'ValidAudiences' configuration is empty or not set.");
                }

                var principal = handler.ValidateToken(token, validationParameters, out var securityToken);
                return principal.Identity.IsAuthenticated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating token");
                return false;
            }
        }
        #endregion
  
    }


}

