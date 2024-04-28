using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.AAAServices
{
    public class UserService
    {
        #region [Private State] 
        private readonly UserManager<OnlineShopUser> _userManager;
        private readonly RoleManager<OnlineShopRole> _roleManager;
        #endregion


        #region [Ctor]
        public UserService(UserManager<OnlineShopUser> userManager, RoleManager<OnlineShopRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        #endregion

        #region [GetAllUsers()]
        public List<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.Select(u => new IdentityUser { UserName = u.UserName }).ToList();
        }
        #endregion

        #region [RegisterUserAsync(CreateUserAppDto model)]
        public async Task<IdentityResult> RegisterUserAsync(CreateUserAppDto model)
        {
            var user = new OnlineShopUser { UserName = model.UserName };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }
        #endregion

        #region [DeleteUserAsync(string userId)]
        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }
            return false;
        }
        #endregion

        #region [GetEditUserRolesViewModelAsync(EditUserRolesAppDto model)]
        public async Task<EditUserRolesAppDto> GetEditUserRolesViewModelAsync(EditUserRolesAppDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.Select(r => new IdentityRole { Name = r.Name }).ToList();

            var editUserRolesAppDto = new EditUserRolesAppDto
            {
                UserName = user.UserName,
                UserId = user.Id,
                Roles = roles,
                UserRoles = userRoles.ToList()
            };

            return editUserRolesAppDto;
        }
        #endregion

        #region [UpdateUserRolesAsync(EditUserRolesAppDto model)]
        public async Task<bool> UpdateUserRolesAsync(EditUserRolesAppDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return false;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            foreach (var item in currentRoles)
            {
                if (!model.UserRoles.Contains(item))
                {
                    var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, item);
                    if (!removeRoleResult.Succeeded)
                    {
                        return false;
                    }
                }
            }

            foreach (var item in model.Roles)
            {
                var isInRole = await _userManager.IsInRoleAsync(user, item.Name);
                if (!isInRole)
                {
                    var addToRoleResult = await _userManager.AddToRoleAsync(user, item.Name);
                    if (!addToRoleResult.Succeeded)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion
    }


}


