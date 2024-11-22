using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

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
            var typeServices = attribute!.Services.Length == 0 ? new[] { type } : attribute.Services;

            foreach (var typeService in typeServices)
            {
#if NET8_0_OR_GREATER
                services.Add(new ServiceDescriptor(typeService, attribute.Key, type, attribute.ServiceLifetime));
#else
                services.Add(new ServiceDescriptor(typeService, type, attribute.ServiceLifetime));
#endif

            }
        }

        return services;
    }
}

