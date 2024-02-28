using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicTools.Constants;

namespace OnlineShop.EFCore.Configurations.SaleConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), DatabaseConstants.Schemas.Sale);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title)
                            .IsRequired()
                            .HasMaxLength(256);
            builder.Property(p => p.UnitPrice)
                  .IsRequired()
                  .HasColumnType("double");

            builder.Property(p => p.IsActivated)
            .IsRequired()
            .HasColumnName("IsActivated")
            .HasColumnType("bit")
            .HasDefaultValue(true);

            builder.Property(p => p.DateSoftDeletedLatin)
              .HasColumnName("DateSoftDeleteLatin")
              .HasColumnType("datetime2");

            builder.Property(p => p.DateSoftDeletedPersian)
                .HasColumnName("DateSoftDeletePersian")
                .HasColumnType("datetime2");

            builder.Property(p => p.IsDeleted)
               .IsRequired()
               .HasColumnName("IsDeleted")
               .HasColumnType("bit");


            builder.Property(p => p.EntityDescription)
               .HasColumnName("EntityDescription")
               .HasColumnType("nvarchar(max)");

            builder.HasIndex(p => p.Title).IsUnique();

        }
    }
}
