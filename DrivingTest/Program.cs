using DrivingTest.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DrivingTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Authenticator/Index"; 
        options.LogoutPath = "/Authenticator/Logout"; 
        options.AccessDeniedPath = "/Error/Blocked"; 

        options.ExpireTimeSpan = TimeSpan.FromHours(1); 
    });

var app = builder.Build();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

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
    pattern: "{controller=Home}/{action=Home}");
app.MapControllerRoute(
    name: "dashboard",
    pattern: "Dashboard/{action}/{id?}",
    defaults: new { controller = "Dashboard", action = "Dashboard_Admin" });




app.Run();