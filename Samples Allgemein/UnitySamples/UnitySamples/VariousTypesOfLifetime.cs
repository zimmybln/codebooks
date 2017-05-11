using Microsoft.Practices.Unity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnitySamples.Types;

namespace UnitySamples
{

    [TestFixture]
    public class VariousTypesOfLifetime
    {
        [Test]
        public void UseInstanceByResolve()
        {
            var container = new UnityContainer();

            container.RegisterTypes(AllClasses.FromLoadedAssemblies());

            var item1 = container.Resolve<InstanceItem>();
            item1.Counter = 10;

            var item2 = container.Resolve<InstanceItem>();
            item2.Counter = 20;

            Assert.IsTrue(item1.Counter == 10);
            Assert.IsTrue(item2.Counter == 20);
            Assert.IsFalse(object.Equals(item1, item2), "They are not different instances");

        }

        [Test]
        public void UseSingletonByResolve()
        {
            var container = new UnityContainer();

            container.RegisterTypes(AllClasses.FromLoadedAssemblies());

            container.RegisterType<InstanceItem>(new ExternallyControlledLifetimeManager());

            var item1 = container.Resolve<InstanceItem>();
            item1.Counter = 10;

            var item2 = container.Resolve<InstanceItem>();
            item2.Counter = 20;

            Assert.IsTrue(item1.Counter == 20);
            Assert.IsTrue(object.Equals(item1, item2), "It's not a singleton object");

        }

    }
}
