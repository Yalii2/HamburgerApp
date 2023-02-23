using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using HamburgerApp.Business.IoC;
using HamburgerApp.Business.Services.OrderService;
using HamburgerApp.DataAccess.EntityFramework.Context;
using HamburgerApp.Models.SeedDataModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HamburgerAppDbContext>(_ =>
{
	_.UseSqlServer(builder.Configuration.GetConnectionString("HamburgerConnStr"));
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
	builder.RegisterModule(new DependencyResolver());
});
builder.Services.AddScoped<IOrderServices, OrderServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

SeedData.Seed(app);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
