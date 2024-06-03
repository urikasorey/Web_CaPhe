using Microsoft.EntityFrameworkCore;
using Web_CaPhee2_api.Models.Services;
using Web_CaPhee2_api.Data;
using Web_CaPhee2_api.Models.Interface;
using Web_CaPhee2_api.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(ShoppingCartRepository.GetCart);
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddDbContext<CoffeeshopApiDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopApiDbContextConnection")));
var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
