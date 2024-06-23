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
        #endregion

        #region [Ctor]
        public AccountService(UserManager<OnlineShopUser> userManager, SignInManager<OnlineShopUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
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
                var token = GenerateToken(authClaims);

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
        private JwtSecurityToken GenerateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
               issuer: _configuration["JWT:ValidIssuer"],
               audience: _configuration["JWT:ValidAudience"],
               expires: DateTime.UtcNow.AddHours(3), // Use UTC time
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
                // Assuming you have a single audience, you can use the first one from the original token
                string audience = jwtToken.Audiences.FirstOrDefault();

                // Create a new token with the same claims but an expired expiration time
                var newToken = new JwtSecurityToken(
                    jwtToken.Issuer,
                    audience,
                    jwtToken.Claims,
                    DateTime.UtcNow, // Use the current UTC time
                    DateTime.UtcNow.AddSeconds(-1), // Set the expiration time to 1 second in the past
                    jwtToken.SigningCredentials
                );

                // Replace the original token with the new, expired token
                token = new JwtSecurityTokenHandler().WriteToken(newToken);
            }
        }
        #endregion
        
        #region [IsTokenValidAsync(string token)]
       public async Task<bool> IsTokenValidAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                handler.ValidateToken(token, validationParameters, out _);
                return true;
            }
            catch (SecurityTokenExpiredException)
            {
                // Token is expired
                return false;
            }
            catch (Exception)
            {
                // Token is invalid
                return false;
            }
        }
        #endregion
    }


}

