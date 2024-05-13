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
    public class ProductRepository : BaseRepository<OnlineShopDbContext, Product, Guid>, IProductRepository
    {
        #region [Ctor]
        public ProductRepository(OnlineShopDbContext onlineShopDbContext) : base(onlineShopDbContext)
        {

        }
        #endregion


        #region [GetAllProducts(bool includeDeleted = false)]
        public async Task<IResponse<IEnumerable<Product>>> GetAllProducts(bool includeDeleted = false)
        {
            try
            {

                var productWithcategory = await DbContext.Set<Product>()
                .Include(p => p.ProductCategories)
                .Where(p => includeDeleted || !p.IsDeleted)
                .ToListAsync();
                return new Response<IEnumerable<Product>>(productWithcategory);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Product>>(null, false, MessageResource.Error_InternalServerError, "Internal server error", HttpStatusCode.InternalServerError);

            }
        }
        #endregion

        #region [GetProductById(Guid id, bool includeDeleted = false)]
        public async Task<IResponse<Product>> GetProductById(Guid id, bool includeDeleted = false)
        {
            try
            {
                var product = await DbContext.Set<Product>()
               .Include(p => p.ProductCategories)
               .FirstOrDefaultAsync(p => (includeDeleted || !p.IsDeleted) && p.Id == id);
                return new Response<Product>(product);
            }


            catch (Exception ex)
            {
                return new Response<Product>(null, false, MessageResource.Error_InternalServerError, "Internal server error", HttpStatusCode.InternalServerError);

            }
        } 
        #endregion


    }
}
