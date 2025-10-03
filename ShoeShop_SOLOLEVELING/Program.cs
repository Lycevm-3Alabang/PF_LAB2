using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Repository.Repositories;
using ShoeShop.Services.Interfaces;
using ShoeShop.Services.Mapping;
using ShoeShop.Services.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Server=localhost;Database=ShoeShopDb;Trusted_Connection=True;MultipleActiveResultSets=true")
);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(ShoeShop.Services.Services.InventoryService));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IShoeRepository, ShoeRepository>();
builder.Services.AddScoped<IStockPullOutRepository, StockPullOutRepository>();


builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IPullOutService, PullOutService>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<IReportService, ReportService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
