using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public class TransientAttribute : LifetimeAttribute
    {
        public TransientAttribute(params Type[] services) : base(ServiceLifetime.Transient, services)
        {
        }
    }
}
