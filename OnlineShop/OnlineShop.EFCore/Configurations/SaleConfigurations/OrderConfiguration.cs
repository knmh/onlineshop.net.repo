using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using PublicTools.Constants;

namespace OnlineShop.EFCore.Configurations.SaleConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable(nameof(OrderDetail), DatabaseConstants.Schemas.Sale);

            // Configure the relationship with Product
            builder.HasOne(od => od.Product)
                   .WithMany()
                   .HasForeignKey(od => od.ProductId); // Assuming ProductId is the foreign key in OrderDetail

            // Configure the relationship with OrderHeader
            builder.HasOne(od => od.OrderHeader)
                   .WithMany()
                   .HasForeignKey(od => od.OrderHeaderId); // Assuming OrderHeaderId is the foreign key in OrderDetail
        }
    }
}
