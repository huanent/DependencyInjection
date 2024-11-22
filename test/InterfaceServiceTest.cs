using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionTest
{
    [TestClass]
    public class InterfaceServiceTest
    {
        [Transient(typeof(IService), typeof(IService2))]
        class Service : IService, IService2 { }

        interface IService { }

        interface IService2 { }


        IServiceProvider _services = new ServiceCollection().AddFromAssemblies(Assembly.GetExecutingAssembly()).BuildServiceProvider();

        [TestMethod]
        public void Has_Interface_Service_Test()
        {
            var service = _services.GetService<IService>();
            var service2 = _services.GetService<IService2>();
            Assert.IsInstanceOfType(service, typeof(Service));
            Assert.IsInstanceOfType(service2, typeof(Service));
        }

        [TestMethod]
        public void Not_Class_Service_Test()
        {
            var service = _services.GetService<Service>();
            Assert.IsNull(service);
        }
    }
}
