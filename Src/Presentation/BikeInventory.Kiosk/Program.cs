using BikeInventory.Kiosk;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BikeInventory.Kiosk.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBikeInventoryDependencies(builder.Configuration);

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthentication("Test_Auth")
    .AddCookie("Test_Auth", options =>
    {
        options.LoginPath = "/Account/Login";
    });

builder.Services.AddHttpContextAccessor();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDefaultIdentity<BikeIdentityUser>()
    .AddUserStore<BikeUserStore>()
    .AddClaimsPrincipalFactory<BikeUserClaimsPrincipalFactory>()
    .AddSignInManager<BikeSignInManager>()
    .AddUserManager<BikeUserManager>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
