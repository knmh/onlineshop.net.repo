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
        public int? ParentCategoryId { get; set; } // Nullable to allow for a top-level category
        public ProductCategory ParentCategory { get; set; } // Reference to the parent category
        public ICollection<ProductCategory> SubCategories { get; set; } // Recursive reference to sub-categories
        public Product Product{ get; set; }
      //  public Guid ProductId { get; set; }

        //Fields
        public long Code { get; set; }
    }
}
