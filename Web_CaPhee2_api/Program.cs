using Microsoft.EntityFrameworkCore;
using Web_CaPhee2_api.Models.Services;
using Web_CaPhee2_api.Data;
using Web_CaPhee2_api.Models.Interface;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Thêm các dịch vụ vào container
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(ShoppingCartRepository.GetCart);
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddDbContext<CoffeeshopApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopApiDbContextConnection")));

// Thêm dịch vụ bộ nhớ cache phân tán và phiên
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Sửa thứ tự của UseSession() và các phần khác
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Đảm bảo app.UseSession() được gọi trước app.UseAuthorization()
app.UseSession();

app.MapControllers();

app.Run();
