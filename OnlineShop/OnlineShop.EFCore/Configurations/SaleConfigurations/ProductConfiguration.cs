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
            builder.ToTable(nameof(Product), DatabaseConstants.Schemas.Sale);
            builder.HasMany(p => p.ProductCategories)
            .WithOne(pc => pc.Product);
           
 














            //     builder.HasMany(p => p.ProductCategories)
            //   .WithMany(pc => pc.Products)
            //   .UsingEntity<ProductProductCategory>(
            //j => j.HasOne(ppc => ppc.ProductCategory).WithMany(),
            //j => j.HasOne(ppc => ppc.Product).WithMany()
            //);





            //builder.Property(p => p.Title)
            //   .IsRequired()
            //   .HasMaxLength(256);

            //builder.Property(p => p.UnitPrice)

            //    .HasColumnType("double");

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
