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
        private readonly List<(string, DateTime)> _blacklistedTokens = new List<(string, DateTime)>();
        #endregion
        #region [Ctor]
        public AccountService(UserManager<OnlineShopUser> userManager, RoleManager<OnlineShopRole> roleManager, IConfiguration configuration, ILogger<AccountService> logger)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _configuration = configuration;
                _logger = logger;
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
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return token;
            }
        #endregion

        public async Task LogoutAsync(string token)
        {
            try
            {
                var (existingToken, expiration) = _blacklistedTokens.FirstOrDefault(t => t.Item1 == token);
                if (existingToken != null && expiration > DateTime.Now)
                {
                    _logger.LogInformation("Token is already in the blacklist.");
                    return;
                }

                var tokenExpiration = new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo;
                _blacklistedTokens.Add((token, tokenExpiration));
                _logger.LogInformation("User logged out successfully.");
                _blacklistedTokens.RemoveAll(t => t.Item2 <= DateTime.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during logout.");
                throw;
            }
        }

        public bool IsTokenValid(string token)
        {
            var (existingToken, expiration) = _blacklistedTokens.FirstOrDefault(t => t.Item1 == token);
            var isTokenBlacklisted = existingToken != null && expiration > DateTime.Now;
            var isTokenInvalidated = !isTokenBlacklisted && _blacklistedTokens.Any(t => t.Item1 == token);

            return !isTokenInvalidated;
        }
    }
}

   

