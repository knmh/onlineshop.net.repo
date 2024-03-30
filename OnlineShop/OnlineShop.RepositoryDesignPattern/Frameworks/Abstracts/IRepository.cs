using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts
{
    public interface IRepository<TEntity, UPrimaryKey> where TEntity : class
    {
        Task<IResponse<TEntity>> SelectByIdAsync(UPrimaryKey? id);
        //list or enum
        Task<IResponse<List<TEntity>>> SelectAllAsync();
        Task<IResponse<object>> InsertAsync(TEntity entity);
        Task<IResponse<object>> DeleteAsync(TEntity entity);
        Task<IResponse<object>> DeleteAsync(UPrimaryKey id);
        Task<IResponse<object>> UpdateAsync(TEntity entity);
        Task<IResponse<object>> UpdateAsync(UPrimaryKey? id);
        //why  no response
        Task SaveAsync();

    }
}
