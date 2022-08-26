using AbidiProducts.Core.ApplicationService.Products.AddProduct;
using AbidiProducts.Core.ApplicationService.Units.AddUnit;
using AbidiProducts.Core.ApplicationService.Units.UpdateUnit;
using AbidiProducts.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var cnnString = builder.Configuration.GetConnectionString("ProductCnn");
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(cnnString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAddProductAppService, AddProductAppService>();
builder.Services.AddScoped<IAddUnitAppService, AddUnitAppService>();
builder.Services.AddScoped<IUpdateUnitAppService, UpdateUnitAppService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
