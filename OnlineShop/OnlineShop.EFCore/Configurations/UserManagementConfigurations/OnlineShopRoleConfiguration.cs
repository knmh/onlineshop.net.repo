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
    public class OnlineShopRoleConfiguration : IEntityTypeConfiguration<OnlineShopRole>
    {
        public void Configure(EntityTypeBuilder<OnlineShopRole> builder)
        {
            builder.ToTable(nameof(OnlineShopRole)).
            HasData(
            new OnlineShopRole()
            {
                Id = DatabaseConstants.DefaultRoles.GodAdminId,
                Name = DatabaseConstants.DefaultRoles.GodAdminName,
                NormalizedName = DatabaseConstants.DefaultRoles.GodAdminNormalizedName,
                ConcurrencyStamp = DatabaseConstants.DefaultRoles.GodAdminConcurrencyStamp,
            },  
            new OnlineShopRole()
            {
                Id = DatabaseConstants.DefaultRoles.AdminId,
                Name = DatabaseConstants.DefaultRoles.AdminName,
                NormalizedName = DatabaseConstants.DefaultRoles.AdminNormalizedName,
                ConcurrencyStamp = DatabaseConstants.DefaultRoles.AdminConcurrencyStamp,
            },
            new OnlineShopRole()
            {
                Id = DatabaseConstants.DefaultRoles.BuyerId,
                Name = DatabaseConstants.DefaultRoles.BuyerName,
                NormalizedName = DatabaseConstants.DefaultRoles.BuyerNormalizedName,
                ConcurrencyStamp = DatabaseConstants.DefaultRoles.BuyerConcurrencyStamp,
            },
            new OnlineShopRole()
            {
                Id = DatabaseConstants.DefaultRoles.SellerId,
                Name = DatabaseConstants.DefaultRoles.SellerName,
                NormalizedName = DatabaseConstants.DefaultRoles.SellerNormalizedName,
                ConcurrencyStamp = DatabaseConstants.DefaultRoles.SellerConcurrencyStamp,
            }


            );
        }
    }
}

