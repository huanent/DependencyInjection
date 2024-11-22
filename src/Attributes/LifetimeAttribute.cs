using System;

namespace Microsoft.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class LifetimeAttribute : Attribute
{
    public LifetimeAttribute(ServiceLifetime serviceLifetime, params Type[] services)
    {
        ServiceLifetime = serviceLifetime;
        Services = services;
    }
    
#if NET8_0_OR_GREATER
    public LifetimeAttribute(object? key, ServiceLifetime serviceLifetime, params Type[] services)
    {
        Key = key;
        ServiceLifetime = serviceLifetime;
        Services = services;
    }
#endif

    public object? Key { get; private set; }
    public ServiceLifetime ServiceLifetime { get; private set; }
    public Type[] Services { get; private set; }
}

