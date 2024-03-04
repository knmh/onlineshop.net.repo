using OnlineShop.Domain.Frameworks.Abstracts;
using OnlineShop.Domain.Frameworks.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class ProductProductCategory : IDescriptionEntity, IDbSetEntity
    {
        //Keys
        public ProductCategory ProductCategory { get; set; }
        public ICollection<Product> Product { get; set; }

        public virtual int ProductCategoryId { get; set; }
        public virtual Guid ProductId { get; set; }
        public string EntityDescription { get; set; }
    }
}
