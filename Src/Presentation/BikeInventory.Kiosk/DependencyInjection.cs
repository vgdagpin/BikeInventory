using System.Reflection;

using BikeInventory.Application;
using BikeInventory.Infrastructure;
using BikeInventory.Kiosk.Common;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BikeInventory.Kiosk
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder AddBikeInventoryDependencies(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddApplication();
            services.AddInfrastructure(configuration, opt =>
            {
                #region Uncomment this for SQLite
                //var dir = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\Temp\BikeInventory\");

                //if (!Directory.Exists(dir))
                //{
                //    Directory.CreateDirectory(dir);
                //}

                //opt.UseSQLite(Path.Combine(dir, "BikeInventory.db")); 
                #endregion

                opt.UseSqlServer();
            });

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddAuthentication("Test_Auth")
                .AddCookie("Test_Auth", options =>
                {
                    options.LoginPath = "/Account/Login";
                });

            services.AddHttpContextAccessor();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDefaultIdentity<IdentityUser>()
                .AddUserManager<BikeUserManager>()
                .AddUserStore<BikeUserStore>()
                .AddClaimsPrincipalFactory<BikeUserClaimsPrincipalFactory>()
                .AddSignInManager<BikeSignInManager>();

            services.AddMemoryCache();
            services.AddControllersWithViews();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.Policy.Administrator, policy =>
                {
                    policy.RequireRole(Constants.UserRoles.Admin);
                });

                options.AddPolicy(Constants.Policy.Staff, policy =>
                {
                    policy.RequireRole(Constants.UserRoles.Staff);
                });
            });

            return builder;
        }
    }
}
