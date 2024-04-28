using Microsoft.AspNetCore.Identity;
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
        private readonly RoleManager<OnlineShopRole> _roleManager;

        public RoleService(RoleManager<OnlineShopRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<List<OnlineShopRole>> GetAllRolesAsync()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var role = new OnlineShopRole { Name = roleName };
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                return await _roleManager.DeleteAsync(role);
            }
            return IdentityResult.Failed(new IdentityError { Description = "Role not found" });
        }
    }
}

