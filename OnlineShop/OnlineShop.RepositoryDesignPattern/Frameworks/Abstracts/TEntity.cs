using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts
{
    public interface TEntity<T>
    {
        T Id { get; set; }
    }
}
