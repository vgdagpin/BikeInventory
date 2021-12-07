using System;

using BikeInventory.Application;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TasqR;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using BikeInventory.Infrastructure.Persistence;
using System.IO;
using BikeInventory.Infrastructure;
using BikeInventory.Application.Repositories;
using BikeInventory.Interfaces;

namespace BikeInventory.AdminConsole
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
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

            services.AddApplication();
            services.AddTasqR(Assembly.GetExecutingAssembly());

            services.AddMemoryCache();

            services.AddScoped<IBikeRepository, TestBikeRepository>();

            return services;
        }
    }
}

