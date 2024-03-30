﻿using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Frameworks.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Services.Repositories.SaleRepositories
{
    public class ProductRepository : BaseRepository<OnlineShopDbContext, Product, Guid>
    {
        #region [Ctor]
        public ProductRepository(OnlineShopDbContext onlineShopDbContext) : base(onlineShopDbContext)
        {

        }
        #endregion
    }
}
