using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore
{
    public class OnlineShopDbContextFactory : IDesignTimeDbContextFactory<OnlineShopDbContext>
    {
        public OnlineShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OnlineShopDbContext>();
         
            optionsBuilder.UseSqlServer
                ("Server=.; Initial Catalog=OnlineShop00;Integrated Security=True; MultipleActiveResultSets=true;Encrypt=False; TrustServerCertificate=True;"
 ); 
            return new OnlineShopDbContext(optionsBuilder.Options);
        }

    }
}
