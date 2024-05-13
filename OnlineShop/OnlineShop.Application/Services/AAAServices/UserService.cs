using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        #region [GetAllUsersWithRolesAsync()]
        public async Task<IEnumerable<GetAllUsersWithRolesAppDto>> GetAllUsersWithRolesAsync()
        {
            

            var users = await _userManager.Users.ToListAsync();
            var userRoleDtos = new List<GetAllUsersWithRolesAppDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleInfo = new List<string>();

                foreach (var roleName in roles)
                {
                    roleInfo.Add(roleName);
                }

                var userRoleDto = new GetAllUsersWithRolesAppDto
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    NationalId = user.NationalId,
                    UserName = user.UserName,
                    Email = user.Email,
                    CellPhone = user.CellPhone,
                    Roles = roleInfo
                };

                userRoleDtos.Add(userRoleDto);
            }

            return userRoleDtos;
        }
        #endregion

        #region [RegisterUserAsync(CreateUserAppDto model)]
        public async Task<IdentityResult> RegisterUserAsync(CreateUserAppDto model)
        {
            var user = new OnlineShopUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                NationalId = model.NationalId,
                UserName = model.UserName,
                Email = model.Email,
                CellPhone = model.CellPhone
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                foreach (var roleId in model.RoleId)
                {
                    var role = await _roleManager.FindByIdAsync(roleId);
                    if (role != null)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else
                    {
                        // Handle the case where the role is not found
                        return IdentityResult.Failed(new IdentityError { Description = $"Role with ID '{roleId}' not found." });
                    }
                }
            }

            return result;
        }



        #endregion

        #region [DeleteUserAsync(DeleteUserAppDto model)]
        public async Task<bool> DeleteUserAsync(DeleteUserAppDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return false;

            // Soft delete the user's associated roles
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var roleName in roles)
            {
                //var role = await _roleManager.FindByNameAsync(roleName);
                //if (role != null)
                //{
                //    // Soft delete the user-role association
                //    await _userManager.RemoveFromRoleAsync(user, roleName);
                //    role.IsDeleted = true;
                //    await _roleManager.UpdateAsync(role);
                //}
            }

            // Soft delete the user
            user.IsDeleted = true;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        #endregion



        #region [UpdateUserRolesAsync(EditUserRolesAppDto model)]
        public async Task<bool> UpdateUserRolesAsync(EditUserRolesAppDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return false;

            // Update user information
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.NationalId = model.NationalId;
            user.CellPhone = model.CellPhone;

            // Update user roles
            var currentRoles = await _userManager.GetRolesAsync(user);
            var rolesToAdd = model.Roles.Where(r => !currentRoles.Contains(r)).ToList();
            var rolesToRemove = currentRoles.Where(r => !model.Roles.Contains(r)).ToList();

            // Add new roles
            foreach (var role in rolesToAdd)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            // Remove old roles
            foreach (var role in rolesToRemove)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }

    #endregion
}





