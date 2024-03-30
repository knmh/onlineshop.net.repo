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
    public class OrderHeaderRepository : BaseRepository<OnlineShopDbContext, OrderHeader, Guid>
    {
        #region [Ctor]
        public OrderHeaderRepository(OnlineShopDbContext onlineShopDbContext) : base(onlineShopDbContext)
        {

        }
        #endregion
    }
}
