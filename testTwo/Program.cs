using Serilog;
using testTwo;
using testTwo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithProperty("ApplicationName", "testTwo");
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();
builder.Services.AddSingleton<ICartsRepository , CartsInMemoryRepository>();
builder.Services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
builder.Services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
builder.Services.AddSingleton<IUsersManager, UsersManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
