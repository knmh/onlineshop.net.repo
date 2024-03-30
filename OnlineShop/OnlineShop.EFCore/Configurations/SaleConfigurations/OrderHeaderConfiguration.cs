using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.SaleConfigurations
{
    public class OrderHeaderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.ToTable(nameof(OrderHeader), DatabaseConstants.Schemas.Sale);
      
            builder.HasOne(o => o.Seller)
           .WithMany()
           .HasForeignKey(o => new { o.SellerUserId, o.SellerRoleId }) 
           .OnDelete(DeleteBehavior.Restrict)
           .HasPrincipalKey(u => new { u.UserId, u.RoleId });

            builder.HasOne(o => o.Buyer)
           .WithMany()
           .HasForeignKey(o => new { o.BuyerUserId, o.BuyerRoleId }) 
           .OnDelete(DeleteBehavior.Restrict)
           .HasPrincipalKey(u => new { u.UserId, u.RoleId });

            builder.HasMany(o => o.OrderDetails)
            .WithOne(d => d.OrderHeader)
            .HasForeignKey(d => d.OrderHeaderId)
            .OnDelete(DeleteBehavior.ClientSetNull);


        }

    }
}
