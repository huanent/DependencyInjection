using System;

namespace Microsoft.Extensions.DependencyInjection;

public class ScopedAttribute : LifetimeAttribute
{
    public ScopedAttribute(params Type[] services) : base(ServiceLifetime.Scoped, services)
    {

    }

#if NET8_0_OR_GREATER
    public ScopedAttribute(object? key, params Type[] services) : base(key, ServiceLifetime.Scoped, services)
    {

    }
#endif

}
