using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.ExtensionsTest
{
    [TestClass]
    public class BasicServiceTest
    {
        [Lifetime(ServiceLifetime.Transient)]
        class LifetimeService { }

        [Transient]
        class TransientService { }

        [Scoped]
        class ScopedService { }

        [Singleton]
        class SingletonService { }

        IServiceProvider _services = new ServiceCollection().AddFromAssemblies(typeof(BasicServiceTest).Assembly).BuildServiceProvider();

        [TestMethod]
        public void LifetimeAttributeTest()
        {
            var service = _services.GetService<LifetimeService>();
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void TransientAttributeTest()
        {
            var service = _services.GetService<TransientService>();
            var service2 = _services.GetService<TransientService>();
            Assert.IsNotNull(service);
            Assert.IsNotNull(service2);
            Assert.AreNotEqual(service, service2);
        }

        [TestMethod]
        public void ScopedAttributeTest()
        {
            var service = _services.GetService<ScopedService>();
            var service2 = _services.GetService<ScopedService>();
            Assert.IsNotNull(service);
            Assert.IsNotNull(service2);
            Assert.AreEqual(service, service2);
        }

        [TestMethod]
        public void SingletonAttributeTest()
        {
            var service = _services.GetService<SingletonService>();
            var service2 = _services.GetService<SingletonService>();
            Assert.IsNotNull(service);
            Assert.IsNotNull(service2);
            Assert.AreEqual(service, service2);
        }
    }
}
