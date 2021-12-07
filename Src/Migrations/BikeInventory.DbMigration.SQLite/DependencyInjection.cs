using System;
using System.IO;
using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Infrastructure.Common;
using BikeInventory.Infrastructure.Persistence;

namespace BikeInventory.Infrastructure
{
    public static class DependencyInjection
    {
        public static void UseSQLite
            (
                this InfrastructureOption option,
                string appDataFile
            )
        {
            option.Services.AddDbContext<BikeInventoryDbContext>((svc, options) =>
            {
                options.UseSqlite
                (
                    connectionString: $"Filename={appDataFile}",
                    sqliteOptionsAction: opt =>
                    {
                        opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                        opt.MigrationsHistoryTable("tbl_MigrationHistory", "adm");
                    }
                );
            });

            option.Services.AddScoped<IBikeInventoryDbContext>(provider => provider.GetService<BikeInventoryDbContext>());
            option.Services.AddScoped<DbContext>(provider => provider.GetService<BikeInventoryDbContext>());
        }
    }
}

