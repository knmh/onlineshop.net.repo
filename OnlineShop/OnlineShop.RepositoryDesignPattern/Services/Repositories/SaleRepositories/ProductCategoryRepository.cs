using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Frameworks.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Services.Repositories.SaleRepositories
{
    public class ProductCategoryRepository : BaseRepository<OnlineShopDbContext, ProductCategory, int>
    {
        #region [Ctor]
        public ProductCategoryRepository(OnlineShopDbContext onlineShopDbContext) : base(onlineShopDbContext)
        {

        }
        #endregion
    }
}
