using System.Reflection;

using BikeInventory.Application;
using BikeInventory.Infrastructure;

namespace BikeInventory.Kiosk
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBikeInventoryDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfrastructure(configuration, opt =>
            {
                //var dir = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\Temp\BikeInventory\");

                //if (!Directory.Exists(dir))
                //{
                //    Directory.CreateDirectory(dir);
                //}

                //opt.UseSQLite(Path.Combine(dir, "BikeInventory.db"));

                opt.UseSqlServer();
            });

            services.AddMemoryCache();

            return services;
        }
    }
}
