using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public class ScopedAttribute : LifetimeAttribute
    {
        public ScopedAttribute(params Type[] services) : base(ServiceLifetime.Scoped, services)
        {

        }
    }
}
