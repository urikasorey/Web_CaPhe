using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Web_CaPhe.Data;
using Web_CaPhe.Models.Interface;
using Web_CaPhe.Models.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

{
    // Các dịch vụ khác được đăng ký ở đây...
    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<CoffeeshopDbContext>();


    builder.Services.AddRazorPages();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IContactRepository, ContactRepository>();

    builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(ShoppingCartRepository.GetCart);
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddDbContext<CoffeeshopDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopDbContextConnection"))); 

    builder.Services.AddSession();
    builder.Services.AddHttpContextAccessor();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseSession();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.MapRazorPages();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
