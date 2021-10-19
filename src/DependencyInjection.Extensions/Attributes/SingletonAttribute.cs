using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public class SingletonAttribute : LifetimeAttribute
    {
        public SingletonAttribute(params Type[] services) : base(ServiceLifetime.Singleton, services)
        {
        }
    }
}
