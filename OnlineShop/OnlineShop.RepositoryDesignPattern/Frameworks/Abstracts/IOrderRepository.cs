using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Frameworks.Abstracts;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts
{
    public interface IOrderRepository : IRepository<OrderHeader, Guid>
    {
        Task<IResponse<OrderHeader>> SelectByIdWithDetailsAsync(Guid orderId);
        Task<IResponse<List<OrderHeader>>> SelectAllWithDetailsAsync(int skip, int take);
    }
}
