using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                options.UseInMemoryDatabase($"Test:{Guid.NewGuid().ToString().Substring(0, 8)}");
                options.ConfigureWarnings(a => a.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            option.Services.AddScoped<IBikeInventoryDbContext>(provider => provider.GetService<BikeInventoryDbContext>());
            option.Services.AddScoped<DbContext>(provider => provider.GetService<BikeInventoryDbContext>());
        }

        private static BikeInventoryDbContext LoadSeeds(this BikeInventoryDbContext dbContext)
        {
            if (dbContext.HasSeedData)
            {
                return dbContext;
            }

            //new User_Configuration().LoadSeedDataTo(dbContext.Users);

            //dbContext.SaveChanges();

           // dbContext.HasSeedData = true;

            return dbContext;
        }
    }


}

