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
    public class VariousTypesOfComposition
    {
        [Test]
        public void ComposeWithFullAssembly()
        {

        }

        [Test]
        public void ComposeWithSelectedTypesFromAssembly()
        {

        }

        [Test]
        public void ComposeWithInstance() 
        {
            // Neuen Container erstellen
            var container = new UnityContainer();

            // Die zu verwendenden Typen registrieren
            container.RegisterInstance<TextWriter>(Console.Out);
            container.RegisterTypes(AllClasses.FromLoadedAssemblies());

            // Gewünschten Typ erstellen
            ComposeableItem car = container.Resolve<ComposeableItem>();

            // ausführen
            car.SayHello();
        }

        [Test]
        public void ComposeWithRuntimeDecision()
        {

        }


    }
}
