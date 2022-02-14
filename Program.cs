using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using downstreem.Data;
using downstreem.Models;
using downstreem.Mapper;
using Serilog;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using downstreem.Services;
using downstreem.Dtos.MockDTO;
using downstreem.Repositories;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File(Path.Combine("C:\\Logs\\", "Test-Log-{Date}.txt"))
    .CreateLogger();

builder.Host.UseSerilog();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");builder.Services.AddDbContext<ApplicationDataContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDataContext>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IImageUpload, ImageUpload>();

builder.Services.AddHttpClient();

builder.Services.AddScoped(typeof(IHttpServices<>), typeof(HttpServices<>));

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.MapRazorPages();

app.Run();
