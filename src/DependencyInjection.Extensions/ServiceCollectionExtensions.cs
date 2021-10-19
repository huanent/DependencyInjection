using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFromAssemblies(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (assemblies == null) throw new ArgumentNullException(nameof(assemblies));

            var types = assemblies.SelectMany(s => s.GetTypes())
                                  .Where(w => w.CustomAttributes.Any(a => typeof(LifetimeAttribute).IsAssignableFrom(a.AttributeType)))
                                  .Where(w => !w.IsAbstract && !w.IsInterface)
                                  .ToArray();

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<LifetimeAttribute>();
                var typeServices = attribute.Services.Any() ? attribute.Services : new[] { type };

                foreach (var typeService in typeServices)
                {
                    services.Add(new ServiceDescriptor(typeService, type, attribute.ServiceLifetime));
                }
            }

            return services;
        }
    }
}
