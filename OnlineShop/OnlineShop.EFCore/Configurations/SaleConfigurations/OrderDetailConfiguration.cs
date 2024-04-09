using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.SaleConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable(nameof(OrderDetail), DatabaseConstants.Schemas.Sale);
            builder.HasKey(o => new { o.OrderHeaderId, o.ProductId });
            builder.Ignore(o => o.Id);

            builder.HasOne(d => d.OrderHeader)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(d => d.OrderHeaderId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasKey(o => new
            {
                o.OrderHeaderId,
                o.ProductId,
            });

        }
}
}
