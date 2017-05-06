using Microsoft.Practices.Unity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnitySamples.Types;
using UnitySamples.Extension;

namespace UnitySamples
{
    [TestFixture]
    public class VariousTypesOfMultiplicity
    {
        [Test]
        public void UseTypesFromInterface()
        {
            var container = new UnityContainer();

            container.AddExtension(new SelectTypesByInterfaceExtension(typeof(IEntity)));

            var entities = container.ResolveAll<IEntity>();

            entities.ToList().ForEach(e => Console.WriteLine(e.GetName()));

            container.Dispose();
            
        }
    }
}
