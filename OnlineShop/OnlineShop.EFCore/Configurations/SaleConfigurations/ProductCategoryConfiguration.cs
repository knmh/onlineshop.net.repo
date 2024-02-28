using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.SaleConfigurations
{
    public class ProductCategoryConfiguration
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(nameof(ProductCategory), DatabaseConstants.Schemas.Sale);
            builder.HasKey(pc => pc.Id);

            // Configure the one-to-many relationship with SubCategories
            builder.HasMany(pc => pc.SubCategories)
                   .WithOne()
                   .HasForeignKey(pc => pc.ParentCategoryId);

            // Configure the many-to-one relationship with ParentCategory
            builder.HasOne(pc => pc.ParentCategory)
                   .WithMany()
                   .HasForeignKey(pc => pc.ParentCategoryId);

            // Define other property configurations
            builder.Property(pc => pc.Code)
                   .IsRequired();

            builder.Property(pc => pc.Title)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(pc => pc.EntityDescription)
                   .HasColumnName("EntityDescription")
                   .HasColumnType("nvarchar(max)");

            builder.HasIndex(pc => pc.Title).IsUnique();
           
           
        }
    }
}
