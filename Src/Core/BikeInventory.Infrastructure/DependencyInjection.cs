using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BikeInventory.Infrastructure.Common;
using BikeInventory.Application.Cache;
using BikeInventory.Infrastructure.Persistence;
using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Interfaces;

namespace BikeInventory.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration,
            Action<InfrastructureOption> option)
        {
            option.Invoke(new InfrastructureOption(services, configuration));

            services.AddHttpClient(Constants.PaymentService.GCash.HttpClientName, (provider, client) =>
            {
                var handlerSettings = provider.GetService<PaymentHandlerSettings>();

                client.BaseAddress = new Uri(handlerSettings[$"{Constants.PaymentService.GCash.HttpClientName}:Url"].TrimEnd('/'));
            });

            services.AddHttpClient(Constants.PaymentService.Paymaya.HttpClientName, (provider, client) =>
            {
                var handlerSettings = provider.GetService<PaymentHandlerSettings>();

                client.BaseAddress = new Uri(handlerSettings[$"{Constants.PaymentService.Paymaya.HttpClientName}:Url"].TrimEnd('/'));
            });

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<PaymentHandlerSettings>();
            services.AddSingleton<IDateTime, AppDateTime>();

            return services;
        }
    }
}

