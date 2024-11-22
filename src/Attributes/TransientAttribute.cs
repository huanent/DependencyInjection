using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public class TransientAttribute : LifetimeAttribute
    {
        public TransientAttribute(params Type[] services) : base(ServiceLifetime.Transient, services)
        {
        }

#if NET8_0_OR_GREATER
        public TransientAttribute(object? key, params Type[] services) : base(key, ServiceLifetime.Transient, services)
        {
        }
#endif

    }
}
