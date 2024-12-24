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

    public class TransientAttribute<TService> : TransientAttribute
    {
        public TransientAttribute() : base([typeof(TService)])
        {
        }

#if NET8_0_OR_GREATER
        public TransientAttribute(object? key) : base(key, [typeof(TService)])
        {
        }
#endif

    }

    public class TransientAttribute<TService1, TService2> : TransientAttribute
    {
        public TransientAttribute() : base([typeof(TService1), typeof(TService2)])
        {
        }

#if NET8_0_OR_GREATER
        public TransientAttribute(object? key) : base(key, [typeof(TService1), typeof(TService2)])
        {
        }
#endif

    }

    public class TransientAttribute<TService1, TService2, TService3> : TransientAttribute
    {
        public TransientAttribute() : base([typeof(TService1), typeof(TService2), typeof(TService3)])
        {
        }

#if NET8_0_OR_GREATER
        public TransientAttribute(object? key) : base(key, [typeof(TService1), typeof(TService2), typeof(TService3)])
        {
        }
#endif

    }
}
