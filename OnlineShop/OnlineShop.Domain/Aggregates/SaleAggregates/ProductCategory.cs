using OnlineShop.Domain.Frameworks.Abstracts;
using OnlineShop.Domain.Frameworks.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class ProductCategory : SimpleEntityBase, IDbSetEntity
    {
        //Keys
        public ICollection<Product> Products { get; set; }
        public int? ParentCategoryId { get; set; } // Nullable to allow for a top-level category
        public ProductCategory ParentCategory { get; set; } // Reference to the parent category
        public ICollection<ProductCategory> SubCategories { get; set; } // Recursive reference to sub-categories

        //Fields
        public long Code { get; set; }
    }
}
