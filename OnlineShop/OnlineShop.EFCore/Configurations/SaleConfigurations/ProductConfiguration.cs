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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), DatabaseConstants.Schemas.Sale) // Set the table name and schema
                 .HasMany(p => p.ProductCategories)
                  .WithMany(p => p.Products);
            //.UsingEntity<ProductProductCategory>(
            //     j => j
            //    .HasOne<ProductCategory>()
            //    .WithMany()
            //    .HasForeignKey(pc => pc.ProductCategoryId),
            //j => j
            //    .HasOne<Product>()
            //    .WithMany()
            //    .HasForeignKey(pc => pc.ProductId),
            //j =>
            //{
            //    j.ToTable(nameof(ProductProductCategory), DatabaseConstants.Schemas.Sale);
            //    j.HasKey(pc => new { pc.ProductId, pc.ProductCategoryId });
            //});




            //builder.Property(p => p.Title)
            //   .IsRequired()
            //   .HasMaxLength(256);

            //builder.Property(p => p.UnitPrice)
            //    .IsRequired()
            //    .HasColumnType("decimal(18, 2)");

            //builder.Property(p => p.IsActivated)
            //    .IsRequired()
            //    .HasColumnName("IsActivated")
            //    .HasColumnType("bit")
            //    .HasDefaultValue(true);

            //builder.Property(p => p.DateSoftDeletedLatin)
            //    .HasColumnName("DateSoftDeleteLatin")
            //    .HasColumnType("datetime2");

            //builder.Property(p => p.DateSoftDeletedPersian)
            //    .HasColumnName("DateSoftDeletePersian")
            //    .HasColumnType("datetime2");

            //builder.Property(p => p.IsDeleted)
            //    .IsRequired()
            //    .HasColumnName("IsDeleted")
            //    .HasColumnType("bit");

            //builder.Property(p => p.EntityDescription)
            //    .HasColumnName("EntityDescription")
            //    .HasColumnType("nvarchar(max)");

            //builder.HasIndex(p => p.Title).IsUnique();

        }
    }
}
