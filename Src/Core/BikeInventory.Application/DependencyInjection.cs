using System;
using System.Linq;
using System.Reflection;

using BikeInventory.Application.Cache;
using BikeInventory.Application.Common;
using BikeInventory.Application.Common.Interfaces;
using BikeInventory.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using TasqR;

namespace BikeInventory.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, bool includeValidators = false)
        {
            services.AddTasqR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());            

            // register all repositories
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(a => typeof(IRepository).IsAssignableFrom(a)
                    && !a.IsAbstract)
                .Select(a => new
                {
                    Repository = a,
                    IRepository = a.GetInterfaces().SingleOrDefault(a => a.Name != typeof(IGenericRepository<>).Name && a != typeof(IRepository))
                })
                .Where(a => a.IRepository != null)
                .ToList()
                .ForEach(t => services.TryAddEnumerable(ServiceDescriptor.Scoped(t.IRepository, t.Repository)));

            return services;
        }
    }
}


