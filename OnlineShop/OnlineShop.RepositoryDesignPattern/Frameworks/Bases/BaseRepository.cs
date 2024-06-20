using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.Domain.Frameworks.Abstracts;
using OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts;
using PublicTools.Resources;
using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Frameworks.Bases
{
    public class BaseRepository<TDbContext, TEntity, UPrimaryKey> : IRepository<TEntity, UPrimaryKey>
           where TEntity : class
           where TDbContext : IdentityDbContext<OnlineShopUser, OnlineShopRole, string,
            IdentityUserClaim<string>, OnlineShopUserRole, IdentityUserLogin<string>,
            IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        #region [Ctor]
        public BaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
        #endregion
        //protected what is
        #region [Props]
        protected virtual TDbContext DbContext { get; set; }
        protected virtual DbSet<TEntity> DbSet { get; set; } 
        #endregion

      
         
        #region [virtual async Task<IResponse<object>> InsertAsync(TEntity entity)]
        public virtual async Task<IResponse<object>> InsertAsync(TEntity entity)
        {
                DbSet.Add(entity);
                await SaveAsync();
                return new Response<object>(entity);
        }
        #endregion
        
        #region [virtual async Task<IResponse<object>> SaveAsync()]
        public virtual async Task SaveAsync()
        {

            await DbContext.SaveChangesAsync();


        }
        #endregion
        //kh.
        #region [virtual async Task<IResponse<IEnumerable<TEntity>>> SelectAllAsync()]
        public virtual async Task<IResponse<List<TEntity>>> SelectAllAsync()
        {

            var entities = await DbSet.ToListAsync();
            return new Response<List<TEntity>>(entities);

        }
        #endregion
        //kh.
        #region [virtual async Task<IResponse<TEntity>> SelectByIdAsync(UPrimaryKey? id)]
        public virtual async Task<IResponse<TEntity>> SelectByIdAsync(UPrimaryKey? id)
        {
              var entity = await DbSet.FindAsync(id);
           // await SaveAsync();
            return new Response<TEntity>(entity);
        }
        #endregion

        #region [UpdateAsync(TEntity entity)]
        public virtual async Task<IResponse<object>> UpdateAsync(TEntity entity)
        { 
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
            return new ResponseFramework.Response<object>(entity);
        }
        #endregion

        #region [virtual async Task<IResponse<object>> DeleteAsync(UPrimaryKey id)]
        public virtual async Task<IResponse<object>> DeleteAsync(UPrimaryKey id)
        {
            var entityToDelete = DbSet.FindAsync(id).Result;
            if (entityToDelete == null) return new ResponseFramework.Response<object>(MessageResource.Error_FailProcess);
            DbSet.Remove(entityToDelete);
            await SaveAsync();
            return new ResponseFramework.Response<object>(entityToDelete);
        }
        #endregion

        #region [virtual async Task<IResponse<object>> DeleteAsync(TEntity entity)]
        public virtual async Task<IResponse<object>> DeleteAsync(TEntity entity)
        {

            DbSet.Remove(entity);
            await SaveAsync();
            return new Response<object>(entity);
        }
        #endregion
    }
}
