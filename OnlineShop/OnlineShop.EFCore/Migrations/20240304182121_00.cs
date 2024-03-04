using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class _00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sale");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_ProductCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalSchema: "UserManagement",
                        principalTable: "ProductCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductProductCategory",
                schema: "Sale",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductCategory", x => new { x.ProductCategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductProductCategory_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "UserManagement",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    ProductProductCategoryProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductProductCategoryProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    DateCreatedLatin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreatedPersian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsModified = table.Column<bool>(type: "bit", nullable: false),
                    DateModifiedLatin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModifiedPersian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateSoftDeletedLatin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSoftDeletedPersian = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductProductCategory_ProductProductCategoryProductCategoryId_ProductProductCategoryProductId",
                        columns: x => new { x.ProductProductCategoryProductCategoryId, x.ProductProductCategoryProductId },
                        principalSchema: "Sale",
                        principalTable: "ProductProductCategory",
                        principalColumns: new[] { "ProductCategoryId", "ProductId" });
                });

            migrationBuilder.CreateTable(
                name: "ProductProductCategory",
                schema: "UserManagement",
                columns: table => new
                {
                    ProductCategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductCategory", x => new { x.ProductCategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductProductCategory_ProductCategory_ProductCategoriesId",
                        column: x => x.ProductCategoriesId,
                        principalSchema: "UserManagement",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductCategory_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "UserManagement",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c030cce5-7958-4404-990f-125a237d26b8", "503843583", "6250bf66-52a4-43cd-baa2-59847cc142a1" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductProductCategoryProductCategoryId_ProductProductCategoryProductId",
                schema: "Sale",
                table: "Product",
                columns: new[] { "ProductProductCategoryProductCategoryId", "ProductProductCategoryProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ParentCategoryId",
                schema: "UserManagement",
                table: "ProductCategory",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductCategory_ProductsId",
                schema: "UserManagement",
                table: "ProductProductCategory",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductCategory",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductProductCategory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "UserManagement");

            migrationBuilder.UpdateData(
                schema: "UserManagement",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0be3a24-53b5-4ac0-8c73-859217af72f2", "1788231615", "2945c217-ce78-4db1-8a92-21e5a1e32774" });
        }
    }
}
