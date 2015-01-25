using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace MEFConsole
{
    [TestFixture]
    public class TestComponentComposition
    {

        /// <summary>
        /// In diesem Testfall wird einer Eigenschaft eines Objektes ein Wert auf einem
        /// Katalog zugeordnet. Dabei wird davon ausgegangen, dass es genau eine Implementierung
        /// dieses Vertrages gibt. Bei mehreren Implementierungen wird ein Fehler erzeugt.
        /// </summary>
        [Test]
        public void AssignToPropertyOfInstance()
        {

            // Erstellung des Kataloges
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            // Erstellung einer neuen Instanz
            var objComponentConnector = new ComponentConnector();

            var batch = new CompositionBatch();
            batch.AddPart(objComponentConnector);
            
            // Ausführen der Komposition
            container.Compose(batch);

            // Überprüfen der Komposition
            objComponentConnector.SayHello(Console.Out);
        }


        [Test]
        public void AssignToPropertyOfInstanceFromList()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            IApplicationExtension extension = container.GetExports<IApplicationExtension>().Select(l => l.Value).FirstOrDefault();

            if (extension != null)
            {
                var objExtension = new ExtensionHost();

                CompositionBatch c = new CompositionBatch();
                c.AddPart(objExtension);
                c.AddPart(extension);

                container.Compose(c);

                objExtension.Extension.SayHello(Console.Out);
            }
        }

        [Test]
        public void AssignToMultipleProperty()
        {
            // Erstellung des Kataloges
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            // Erstellung einer neuen Instanz
            var objExtensionHostWithMany = new ExtensionHostWithMany();

            var batch = new CompositionBatch();
            batch.AddPart(objExtensionHostWithMany);
            
            // Ausführen der Komposition
            container.Compose(batch);

            // Überprüfen der Komposition
            foreach(IApplicationExtension objExtension in objExtensionHostWithMany.Extensions)
            {
                objExtension.SayHello(Console.Out);
            }


        }

    }
}
