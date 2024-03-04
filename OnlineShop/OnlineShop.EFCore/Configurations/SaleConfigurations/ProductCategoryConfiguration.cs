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
    internal class ProductCategoryConfiguration
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(nameof(ProductCategory), DatabaseConstants.Schemas.Sale);

            builder.HasOne(pc => pc.ParentCategory)
                .WithMany(pc => pc.SubCategories)
                .HasForeignKey(pc => pc.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Define the delete behavior as needed

            builder.HasMany(pc => pc.SubCategories)
                .WithOne(pc => pc.ParentCategory)
                .HasForeignKey(pc => pc.ParentCategoryId);
        }
    }
}
