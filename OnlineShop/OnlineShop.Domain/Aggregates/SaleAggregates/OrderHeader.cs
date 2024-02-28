using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.Domain.Frameworks.Abstracts;
using OnlineShop.Domain.Frameworks.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.SaleAggregates
{
    public class OrderHeader : MainEntityBase, IDbSetEntity
    {
        //keys
        public OnlineShopUserRole Seller { get; set; }
        public OnlineShopUserRole buyer { get; set; }
    }
}
