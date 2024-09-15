using InstutueWeb.Data.Context;
using InstutueWeb.Data.Daos;
using InstutueWeb.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InstituteDbContext>(options =>
                                          options.UseSqlServer(builder.Configuration.GetConnectionString("InstituteDb")));

builder.Services.AddTransient<IDepartment, DaoDepartment>();




builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
