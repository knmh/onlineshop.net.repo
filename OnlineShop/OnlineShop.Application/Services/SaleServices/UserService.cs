using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Application.Dtos.SaleDtos.AccountAppDtos;
using OnlineShop.Application.Dtos.SaleDtos.UserAppDtos;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.SaleServices
{
    public class UserService
    {
        #region [Private State] 
        private readonly UserManager<OnlineShopUser> _userManager;
        #endregion

        #region [Ctor]
        public UserService(UserManager<OnlineShopUser> userManager )
        {
            _userManager = userManager;
        }
        #endregion


        #region [SignUpAsync(SignUpAppDto model)]
        public async Task<IdentityResult> SignUpAsync(SignUpAppDto model)
        {
            var user = new OnlineShopUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true,
                CellPhone=model.CellPhone,
                FirstName=model.FirstName,
                LastName=model.LastName,
                NationalId=model.NationalId,
                LastSignInTime = DateTime.UtcNow,
                LastSignOutTime = null
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            // If the user is created successfully, add default roles or other setup
            if (result.Succeeded)
            {
                // For example, add the user to a default role
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result;
        }
        #endregion

    }

}



