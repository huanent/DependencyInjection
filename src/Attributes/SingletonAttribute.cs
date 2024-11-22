using System;

namespace Microsoft.Extensions.DependencyInjection;

public class SingletonAttribute : LifetimeAttribute
{
    public SingletonAttribute(params Type[] services) : base(ServiceLifetime.Singleton, services)
    {
    }

#if NET8_0_OR_GREATER
    public SingletonAttribute(object? key, params Type[] services) : base(key, ServiceLifetime.Singleton, services)
    {
    }
#endif

}
