using TaskManager.Models;
using Microsoft.EntityFrameworkCore;
using TaskManager.Services;
using TaskManager.Repositories;
using Microsoft.AspNetCore.Identity;
using TaskManager.Interfaces;
using TaskManager.Validators;

var builder = WebApplication.CreateBuilder(args);
string connectionString = "Server=localhost;Database=taskmanagerdb;User=root;Password=;Port=3307";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo que dura la sesión
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddDbContext<TaskManagerDbContext>(options =>
    options.UseMySql(connectionString,
		ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
