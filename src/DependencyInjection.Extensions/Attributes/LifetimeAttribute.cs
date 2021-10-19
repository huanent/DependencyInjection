using System;

namespace Microsoft.Extensions.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class LifetimeAttribute : Attribute
    {
        public LifetimeAttribute(ServiceLifetime serviceLifetime, params Type[] services)
        {
            ServiceLifetime = serviceLifetime;
            Services = services;
        }

        public ServiceLifetime ServiceLifetime { get; private set; }
        public Type[] Services { get; private set; }
    }
}
