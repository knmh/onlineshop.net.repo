﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.EFCore;

#nullable disable

namespace OnlineShop.EFCore.Migrations
{
    [DbContext(typeof(OnlineShopDbContext))]
    partial class OnlineShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("UserManagement")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "UserManagement");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "UserManagement");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", "UserManagement");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "UserManagement");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderHeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreatedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateCreatedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateModifiedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateModifiedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSoftDeletedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateSoftDeletedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsModified")
                        .HasColumnType("bit");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderHeaderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail", "Sale");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.OrderHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BuyerRoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuyerUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreatedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateCreatedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateModifiedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateModifiedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSoftDeletedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateSoftDeletedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsModified")
                        .HasColumnType("bit");

                    b.Property<string>("SellerRoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SellerUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuyerUserId", "BuyerRoleId");

                    b.HasIndex("SellerUserId", "SellerRoleId");

                    b.ToTable("OrderHeader", "Sale");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreatedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateCreatedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateModifiedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateModifiedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSoftDeletedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateSoftDeletedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsModified")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Product", "Sale");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<string>("EntityDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory", "Sale");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", "UserManagement");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "1",
                            IsActive = false,
                            Name = "GodAdmin",
                            NormalizedName = "GODADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "2",
                            IsActive = false,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "4",
                            ConcurrencyStamp = "4",
                            IsActive = false,
                            Name = "Buyer",
                            NormalizedName = "BUYER"
                        },
                        new
                        {
                            Id = "3",
                            ConcurrencyStamp = "3",
                            IsActive = false,
                            Name = "Seller",
                            NormalizedName = "SELLER"
                        },
                        new
                        {
                            Id = "5",
                            ConcurrencyStamp = "5",
                            IsActive = false,
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CellPhoneConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreatedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateCreatedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateModifiedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateModifiedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSoftDeletedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateSoftDeletedPersian")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsModified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastSignInTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastSignOutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NationalIdConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", "UserManagement");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            CellPhone = "09120816075",
                            CellPhoneConfirmed = false,
                            ConcurrencyStamp = "a2033865-e951-4b8f-bf34-99866bdf85fe",
                            DateCreatedLatin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModifiedLatin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateSoftDeletedLatin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Hediyeh",
                            IsActivated = false,
                            IsDeleted = false,
                            IsModified = false,
                            LastName = "Kianmehr",
                            LockoutEnabled = false,
                            NationalId = "0020325721",
                            NationalIdConfirmed = true,
                            PasswordHash = "-106131394",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8b80db68-6b3a-4d98-80ff-b408fc8691db",
                            TwoFactorEnabled = false,
                            UserName = "09120816075"
                        });
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUserActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreatedLatin")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateCreatedPersian")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OnlineShopUserRoleRoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OnlineShopUserRoleUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OnlineShopUserRoleUserId", "OnlineShopUserRoleRoleId");

                    b.ToTable("OnlineShopUserActivity", "UserManagement");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "UserManagement");

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.OrderDetail", b =>
                {
                    b.HasOne("OnlineShop.Domain.Aggregates.SaleAggregates.OrderHeader", "OrderHeader")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderHeaderId")
                        .IsRequired();

                    b.HasOne("OnlineShop.Domain.Aggregates.SaleAggregates.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderHeader");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.OrderHeader", b =>
                {
                    b.HasOne("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUserRole", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerUserId", "BuyerRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUserRole", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerUserId", "SellerRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.ProductCategory", b =>
                {
                    b.HasOne("OnlineShop.Domain.Aggregates.SaleAggregates.ProductCategory", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OnlineShop.Domain.Aggregates.SaleAggregates.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentCategory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUserActivity", b =>
                {
                    b.HasOne("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUserRole", "OnlineShopUserRole")
                        .WithMany()
                        .HasForeignKey("OnlineShopUserRoleUserId", "OnlineShopUserRoleRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OnlineShopUserRole");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUserRole", b =>
                {
                    b.HasOne("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Domain.Aggregates.UserManagementAggregates.OnlineShopUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.OrderHeader", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("OnlineShop.Domain.Aggregates.SaleAggregates.ProductCategory", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
