    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;
    using OnlineShop.Application.Dtos.AAADtos;
    using OnlineShop.Domain.Aggregates.UserManagementAggregates;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    namespace OnlineShop.Application.Services.AAAServices
    {
        public class AccountService
        {
            #region [Private State] 
            private readonly UserManager<OnlineShopUser> _userManager;
            private readonly RoleManager<OnlineShopRole> _roleManager;
            private readonly IConfiguration _configuration;
            private readonly ILogger<AccountService> _logger;
             private readonly JwtSecurityTokenHandler _jwtTokenHandler; // Add this line

        //private readonly List<(string, DateTime)> _blacklistedTokens = new List<(string, DateTime)>();
        #endregion
        #region [Ctor]
        public AccountService(UserManager<OnlineShopUser> userManager, RoleManager<OnlineShopRole> roleManager, IConfiguration configuration, ILogger<AccountService> logger)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _configuration = configuration;
                _logger = logger;
               _jwtTokenHandler = new JwtSecurityTokenHandler();
        }
            #endregion

            #region [LoginAsync(LoginAppDto model)]
            public async Task<AuthenticateResponseAppDto> LoginAsync(LoginAppDto model)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = GenerateToken(authClaims);

                    return new AuthenticateResponseAppDto
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    };
                }
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



        public void ExpireToken(string token)
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
    }
}

   

