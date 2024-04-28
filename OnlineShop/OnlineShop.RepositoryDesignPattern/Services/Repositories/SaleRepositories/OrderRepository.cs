using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts;
using OnlineShop.RepositoryDesignPattern.Frameworks.Bases;
using PublicTools.Resources;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Services.Repositories.SaleRepositories
{
    public class OrderRepository : BaseRepository<OnlineShopDbContext, OrderHeader, Guid>,IOrderRepository
    {
        #region [Ctor]
        public OrderRepository(OnlineShopDbContext onlineShopDbContext) : base(onlineShopDbContext)
        {
             
        }
        #endregion

        #region [SelectByIdWithDetailsAsync(Guid orderId)]
        public async Task<IResponse<OrderHeader>> SelectByIdWithDetailsAsync(Guid orderId)
        {
            try
            {
                var order = await DbContext.Set<OrderHeader>()
                    .Include(o => o.OrderDetails)
                    .FirstOrDefaultAsync(o => o.Id == orderId);

                if (order != null)
                {
                    return new Response<OrderHeader>(order);
                }
                else
                {
                    return new Response<OrderHeader>(MessageResource.Error_FailProcess);
                }
            }
            catch (Exception ex)
            {

                return new Response<OrderHeader>(null, false, MessageResource.Error_InternalServerError, "Internal server error", HttpStatusCode.InternalServerError);
            }
        }
        #endregion

        #region [SelectAllWithDetailsAsync()]
        public async Task<IResponse<List<OrderHeader>>> SelectAllWithDetailsAsync(int skip, int take)
        {
            try
            {
                var ordersWithDetails = await DbContext.Set<OrderHeader>()
                    .Include(o => o.OrderDetails)
                     .Skip(skip)
                     .Take(take)
                    .ToListAsync();

                return new Response<List<OrderHeader>>(ordersWithDetails);
            }
            catch (Exception ex)
            {
                return new Response<List<OrderHeader>>(null, false, MessageResource.Error_InternalServerError, "Internal server error", HttpStatusCode.InternalServerError);
            }
        } 
        #endregion
    }
}
    


    


