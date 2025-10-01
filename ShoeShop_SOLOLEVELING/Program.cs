using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using Microsoft.Extensions.Configuration; // KINAKAILANGAN ITO PARA GUMANA ANG GetConnectionString

var builder = WebApplication.CreateBuilder(args);

// IDAGDAG ANG LINES NA ITO PARA I-REGISTER ANG DB CONTEXT
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ShoeShopDbContext>(options =>
{
    options.UseSqlite(connectionString);
});
// TAPOS DITO

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
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