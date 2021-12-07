using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using BikeInventory.Infrastructure.Persistence;
using System.IO;
using BikeInventory.Application.Common.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BikeInventory.Interfaces;

namespace BikeInventory.AdminConsole
{
    public class Program : IDesignTimeDbContextFactory<BikeInventoryDbContext>
    {
        static void Main(string[] args)
        {
            ServiceProvider.GetService<BikeInventoryDbContext>().Database.Migrate();

            var bikeModelRepository = ServiceProvider.GetService<IBikeModelRepository>();

            var getAllBikes = bikeModelRepository.GetAll();

            Console.WriteLine("Hello World!");
        }



        #region Configuration
        private static IConfiguration configuration = null;
        public static IConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    var configBuilder = new ConfigurationBuilder();

                    configBuilder.SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddUserSecrets(Assembly.GetExecutingAssembly());

                    configuration = configBuilder.Build();
                }

                return configuration;
            }
        }
        #endregion

        #region ServiceProvider
        private static IServiceProvider serviceProvider;
        public static IServiceProvider ServiceProvider
        {
            get
            {
                if (serviceProvider == null)
                {
                    serviceProvider = new ServiceCollection()
                        .ConfigureServices(Configuration)
                        .BuildServiceProvider();
                }

                return serviceProvider;
            }
        }
        #endregion

        public BikeInventoryDbContext CreateDbContext(string[] args) => ServiceProvider.GetService<BikeInventoryDbContext>();
    }
}

