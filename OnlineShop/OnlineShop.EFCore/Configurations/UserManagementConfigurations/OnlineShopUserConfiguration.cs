using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.UserManagementConfigurations
{
    public class OnlineShopUserConfiguration : IEntityTypeConfiguration<OnlineShopUser>
    {
        public void Configure(EntityTypeBuilder<OnlineShopUser> builder)
        {
            #region [- GodAdminUsers Data Entry -]
            builder.ToTable(nameof(OnlineShopUser))
                .HasData(
                new OnlineShopUser
                {
                    Id = DatabaseConstants.GodAdminUsers.KianmehrUserId,
                    FirstName = DatabaseConstants.GodAdminUsers.KianmehrFirstName,
                    LastName = DatabaseConstants.GodAdminUsers.KianmehrLastName,
                    NationalId = DatabaseConstants.GodAdminUsers.KianmehrNationalId,
                    NationalIdConfirmed = true,
                    UserName = DatabaseConstants.GodAdminUsers.KianmehrUserName,
                    PasswordHash = DatabaseConstants.GodAdminUsers.KianmehrPassword.GetHashCode().ToString(),
                    CellPhone = DatabaseConstants.GodAdminUsers.KianmehrCellphone
                });

            //       builder.ToTable(table => table.HasCheckConstraint(
            //DatabaseConstants.CheckConstraints.CellphoneOnlyNumericalTitle,
            //DatabaseConstants.CheckConstraints.CellphoneOnlyNumerical));
            //builder.ToTable(table => table.HasCheckConstraint(
            //    DatabaseConstants.CheckConstraints.NationalIdOnlyNumericalTitle,
            //    DatabaseConstants.CheckConstraints.NationalIdOnlyNumerical));

            //builder.ToTable(table => table.HasCheckConstraint(
            //    DatabaseConstants.CheckConstraints.NationalIdCharacterNumberTitle,
            //    DatabaseConstants.CheckConstraints.NationalIdCharacterNumber));

            //builder.Property(p => p.CellPhone).IsRequired();
            //builder.HasIndex(p => p.CellPhone).IsUnique();

            //builder.Property(p => p.NationalId).IsRequired();
            //builder.HasIndex(p => p.NationalId).IsUnique();
            //builder.Property(p => p.NationalIdConfirmed).HasDefaultValue(false);

            //builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);
            //builder.Property(p => p.DateCreatedLatin).IsRequired().HasDefaultValue(System.DateTime.Now);
            //builder.Property(p => p.IsModified).HasDefaultValue(false);
            //builder.Property(p => p.IsDeleted).HasDefaultValue(false);
                
            //    );
            #endregion
        }
    }
}
