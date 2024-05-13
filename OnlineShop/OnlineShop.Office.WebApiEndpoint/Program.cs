using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Services.Contracts;
using OnlineShop.Application.Services.SaleServices;
using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts;
using OnlineShop.RepositoryDesignPattern.Services.Repositories.SaleRepositories;

var builder = WebApplication.CreateBuilder(args);
#region [EF Service Configuration]
var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:Default");
builder.Services.AddDbContext<OnlineShopDbContext>(c => c.UseSqlServer(connectionString), ServiceLifetime.Scoped);

#endregion
// Add services to the container.
#region [Identity Service Configuration]
builder.Services.AddIdentity<OnlineShopUser, OnlineShopRole>()
    .AddEntityFrameworkStores<OnlineShopDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
});
#endregion
#region [Repository Lifetime Configuration]
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IRepository<OrderHeader, Guid>, OrderRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IRepository<OrderDetail, Guid>, OrderDetailRepository>();
//builder.Services.AddScoped<IRepository<OrderDetail, Guid>, OrderDetailRepository>();
builder.Services.AddScoped<IRepository<ProductCategory, int>, ProductCategoryRepository>();
#endregion
#region [ApplicationService Lifetime Configuration]
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
