using OnlineShop.Domain.Aggregates.SaleAggregates;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts
{
    public interface IProductRepository: IRepository<Product, Guid>
    {
        Task<IResponse<IEnumerable<Product>>> GetAllProducts(bool includeDeleted = false);
        Task <IResponse<Product>> GetProductById(Guid id, bool includeDeleted = false);
    }
}
