using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Dtos.SaleDtos.ProductAppDtos;
using OnlineShop.Application.Services.Contracts;
//using OnlineShop.Application.Services.SaleServices;
//using OnlineShop.Domain.Aggregates.SaleAggregates;
using OnlineShop.EFCore;
using OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts;
//using OnlineShop.RepositoryDesignPattern.Services.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<OnlineShopDbContext>(options =>
{
    options.UseSqlServer("Default ");
});

#region [EF Service Configuration]
//var conectionString = builder.Configuration.GetValue<string>("ConnectionStrings:Default");
//builder.Services.AddDbContext<OnlineShopDbContext>(c => c.UseSqlServer(conectionString));
#endregion
#region [- Identity Service Configuration -]
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<OnlineShopDbContext>();
builder.Services.Configure<IdentityOptions>(c =>
{
    c.Password.RequireDigit = false;
    c.Password.RequireNonAlphanumeric = false;
    c.Password.RequiredLength = 3;
    c.Password.RequireUppercase = false;
    c.Password.RequireLowercase = false;
}
);
#endregion
#region [ApplicationService lifetime Configuration]
//builder.Services.AddScoped<IProductService<PostProductAppDto, PutProductAppDto, DeleteProductAppDto, GetAllProductAppDto>, ProductService>();
#endregion

//#region [ApplicationService lifetime Configuration]
//builder.Services.AddScoped<IRepository<Product, Guid>, ProductRepository>();
//#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//using (var scope = builder.Services.BuildServiceProvider().CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<OnlineShopDbContext>();
//    dbContext.Database.Migrate();
//}

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
