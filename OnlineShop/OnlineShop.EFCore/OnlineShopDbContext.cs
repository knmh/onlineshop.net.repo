using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Frameworks.Abstracts;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OnlineShop.EFCore.Frameworks;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;

namespace OnlineShop.EFCore
{
    public class OnlineShopDbContext : IdentityDbContext<OnlineShopUser, OnlineShopRole, string,
        IdentityUserClaim<string>, OnlineShopUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    { 
        #region [ctor]
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
        {

        }
        #endregion
         
        #region [- OnModelCreating(ModelBuilder modelBuilder) -]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DatabaseConstants.Schemas.UserManagement);

            #region [ApplyConfigurationsFromAssembly()]
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            #endregion

            #region [RegisterAllEntities()]
            modelBuilder.RegisterAllEntities<IDbSetEntity>(typeof(IDbSetEntity).Assembly);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}

