
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using OnlineShop.Domain.Aggregates.UserManagementAggregates;
    using PublicTools.Constants;
    using OnlineShop.Domain.Frameworks.Abstracts;
    using OnlineShop.EFCore.Frameworks;

    namespace OnlineShop.EFCore
    {
        public class OnlineShopDbContext : IdentityDbContext<OnlineShopUser, OnlineShopRole, string,
            IdentityUserClaim<string>, OnlineShopUserRole, IdentityUserLogin<string>,
            IdentityRoleClaim<string>, IdentityUserToken<string>>
        {
            #region [- ctor -]
            public OnlineShopDbContext(DbContextOptions options) : base(options)
            {
            }
            #endregion

            #region [- ConfigureConventions(ModelConfigurationBuilder configurationBuilder) -]
            protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
            {

            }
            #endregion

            #region [- OnModelCreating(ModelBuilder modelBuilder) -]
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.HasDefaultSchema(DatabaseConstants.Schemas.UserManagement);
             
                #region [- ApplyConfigurationsFromAssembly() -]
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                #endregion

                #region [- RegisterAllEntities() -]
                modelBuilder.RegisterAllEntities<IDbSetEntity>(typeof(IDbSetEntity).Assembly);
                #endregion

                base.OnModelCreating(modelBuilder);
            }
            #endregion
        }
    }
