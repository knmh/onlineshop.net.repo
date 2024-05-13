using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Dtos.AAADtos;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.AAAServices
{
    public class RoleService
    {
        #region [Private State] 
        private readonly RoleManager<OnlineShopRole> _roleManager;
        #endregion

        #region [Ctor]
        public RoleService(RoleManager<OnlineShopRole> roleManager)
        {
            _roleManager = roleManager;
        }
        #endregion
        #region [GetAllRolesAsync()]
        public async Task<List<GetAllRolesAppDto>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var dtos = new List<GetAllRolesAppDto>();

            foreach (var role in roles)
            {
                dtos.Add(new GetAllRolesAppDto
                {
                    Id = role.Id,
                    RoleName = role.Name
                });
            }

            return dtos;
        }
        #endregion

        #region [CreateRoleAsync(CreateRoleAppDto model)]
        public async Task<IdentityResult> CreateRoleAsync(CreateRoleAppDto model)
        {
            var role = new OnlineShopRole { Name = model.RoleName };
            return await _roleManager.CreateAsync(role);
        }
        #endregion

        #region [DeleteRoleAsync(DeleteRoleAppDto model)]
        public async Task<IdentityResult> DeleteRoleAsync(DeleteRoleAppDto model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role != null)
            {
                return await _roleManager.DeleteAsync(role);
            }
            return IdentityResult.Failed(new IdentityError { Description = "Role not found" });
        }
        #endregion
        #region [UpdateRoleAsync(UpdateRoleAppDto model)]
        public async Task<IdentityResult> UpdateRoleAsync(UpdateRoleAppDto model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role != null)
            {
                role.Name = model.RoleName;
                return await _roleManager.UpdateAsync(role);
            }
            return IdentityResult.Failed(new IdentityError { Description = "Role not found" });
        }
        #endregion
    }
}

    


