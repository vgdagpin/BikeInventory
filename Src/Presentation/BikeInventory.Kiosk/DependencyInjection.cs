using System.Reflection;

using BikeInventory.Application;
using BikeInventory.Infrastructure;
using BikeInventory.Kiosk.Common;

using Microsoft.AspNetCore.Identity;

namespace BikeInventory.Kiosk
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder AddBikeInventoryServices(this WebApplicationBuilder builder)
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
            services.AddAuthentication(Constants.IdentityConstants.ApplicationScheme)
                .AddCookie(Constants.IdentityConstants.ApplicationScheme, options =>
                {
                    options.LoginPath = "/Account/Login";
                });

            services.AddHttpContextAccessor();

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
