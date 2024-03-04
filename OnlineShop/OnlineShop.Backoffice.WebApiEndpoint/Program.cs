using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using OnlineShop.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add your configuration setup here
#region [EF Service Configuration]
var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:Default");
builder.Services.AddDbContext<OnlineShopDbContext>(c => c.UseSqlServer(connectionString));
#endregion

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

// Add services to the container.


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
