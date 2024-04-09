using OnlineShop.Domain.Frameworks.Abstracts;
using OnlineShop.Domain.Frameworks.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class Product : MainEntityBase, IDbSetEntity
    {
        //Key
        public ICollection<ProductCategory> ProductCategories { get; set; }
        //Fields
        public double UnitPrice { get; set; }
    }
}
