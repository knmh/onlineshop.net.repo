using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore.Migrations;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.SaleConfigurations
{
    public class ProductProductCategoryConfiguration : IEntityTypeConfiguration<ProductProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductProductCategory> builder)
        {
            builder.ToTable(nameof(ProductProductCategory), DatabaseConstants.Schemas.Sale);

            builder.HasKey(p => new
            {
                p.ProductCategoryId,
                p.ProductId,
            });
        }
    }
}
