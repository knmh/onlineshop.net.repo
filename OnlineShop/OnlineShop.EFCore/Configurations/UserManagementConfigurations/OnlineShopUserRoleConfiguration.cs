using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.UserManagementConfigurations
{
    public class OnlineShopUserRoleConfiguration : IEntityTypeConfiguration<OnlineShopUserRole>
    {
        public void Configure(EntityTypeBuilder<OnlineShopUserRole> builder)
        {
            builder.ToTable(nameof(OnlineShopUserRole))
                   .HasData(
                       new OnlineShopUserRole() { UserId = DatabaseConstants.GodAdminUsers.KianmehrUserId, RoleId = DatabaseConstants.DefaultRoles.GodAdminId }
                   );
            builder.HasKey(p => new
            {
                p.UserId,
                p.RoleId,
            });
        }
    }
}
