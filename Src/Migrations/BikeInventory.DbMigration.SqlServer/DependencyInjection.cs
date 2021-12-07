using System;
using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Infrastructure.Common;
using BikeInventory.Infrastructure.Persistence;

namespace BikeInventory.Infrastructure
{
    public static class DependencyInjection
    {
        public static void UseSqlServer
            (
                this InfrastructureOption option,
                string conString = null
            )
        {
            var conStr = conString ?? option.Configuration.GetConnectionString($"{nameof(BikeInventoryDbContext)}_MSSQLConStr");

            option.Services.AddDbContext<BikeInventoryDbContext>((svc, options) =>
            {
                options.UseSqlServer
                (
                    connectionString: conStr,
                    sqlServerOptionsAction: opt =>
                    {
                        opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                        opt.MigrationsHistoryTable("tbl_MigrationHistory", Constants.SchemaConstant.Admin);
                    }
                );
            });

            option.Services.AddScoped<IBikeInventoryDbContext>(provider => provider.GetService<BikeInventoryDbContext>());
            option.Services.AddScoped<DbContext>(provider => provider.GetService<BikeInventoryDbContext>());
        }
    }
}


