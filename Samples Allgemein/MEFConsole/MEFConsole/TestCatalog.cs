using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NUnit.Framework;

namespace MEFConsole
{
    /*
     *      Zielsetzungen: 
     *          - Aus einer Liste eines spezifischen Vertrages soll eine bestimmte Implementierung auswählbar sein, die zugeordnet wird
     *          
     *      http://msdn.microsoft.com/de-de/magazine/ee291628.aspx
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */
    
    [TestFixture]
    public class TestCatalog
    {

        // http://msdn.microsoft.com/de-de/library/ee332203.aspx
        // http://msdn.microsoft.com/en-us/magazine/ee291628.aspx

        /// <summary>
        /// Liest alle Komponenten, die die Schnittstelle IApplicationExtension exportieren.
        /// </summary>
        /// <remarks>
        /// Die Komponenten sind im Moment der Abfrage erstellt. 
        /// </remarks>
        [Test]
        public  void CreateComponentInstances()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            foreach(var i in container.GetExportedValues<IApplicationExtension>())
            {
                i.SayHello(Console.Out);
            }

            catalog.Dispose();
        }

        /// <summary>
        /// Versucht auf eine exportierte Komponente zuzugreifen, so als ob es auschließlich einen Export davon geben
        /// würde. Da es jedoch mehrere Instanzen gibt, wird eine Ausnahme erstellt. 
        /// </summary>
        [Test]
        [TestCase(ExpectedException = typeof(System.ComponentModel.Composition.ImportCardinalityMismatchException))]
        public void TryToCreateLazyComponentInstances()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            var ctl = container.GetExportedValue<IApplicationExtension>();

            if (ctl != null)
                ctl.SayHello(Console.Out);

            catalog.Dispose();
        }

        /// <summary>
        /// Erstellt eine Sammlung von Lazy Components.
        /// </summary>
        [Test]
        public void CreateLazyComponentInstances()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            var colExportedItems = container.GetExports<IApplicationExtension>();

            colExportedItems.ToList().ForEach(x => x.Value.SayHello(Console.Out));
            
            catalog.Dispose();
        }

        /// <summary>
        /// Erstellt eine Sammlung von Lazy Components.
        /// </summary>
        [Test]
        public void CreateLazyComponentInstancesWithCatalog()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            var colExportedItems = container.GetExports<IApplicationExtension, IExtensionInfo>();

            Console.WriteLine("Anzahl exportierter Einträge: {0}", colExportedItems.Count());

            foreach (var i in from c in colExportedItems where c.Metadata.ExtensionType == ExtensionType.Client select c)
            {
                i.Value.SayHello(Console.Out);
            }

            catalog.Dispose();
        }

        [Test]
        public void CreateFilteredCatalog()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var parent = new CompositionContainer(catalog);

            var filteredCat = new FilteredCatalog(catalog,
                def => def.Metadata.ContainsKey(CompositionConstants.PartCreationPolicyMetadataName) && 
                ((CreationPolicy)def.Metadata[CompositionConstants.PartCreationPolicyMetadataName]) == CreationPolicy.NonShared);

            var child = new CompositionContainer(filteredCat, parent);
            
            var root = child.GetExport<ConnectorUsingByConstructor>("Connector");
            child.Dispose();

            root.Value.Connector.SayHello(Console.Out);
        }

        /// <summary>
        /// Es wird einer bestehenden Instanz Werte aus einer Komposition 
        /// zugeordnet.
        /// </summary>
        [Test]
        public void AssignToExistingClass()
        {

            // Erstellung des Kataloges
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly()));

            var container = new CompositionContainer(catalog);

            // Erstellung der Instanz, der anschließend
            // ein Wert zugeordnet wird.
            var h = new ConnectorUsingByProperty();

            // Zuordnen einer bestehenden Instanz
            var batchForExistingInstance = new CompositionBatch();

            batchForExistingInstance.AddPart(h);

            container.Compose(batchForExistingInstance);

            // Aufruf der zugeordneten Werte
            h.Connector.SayHello(Console.Out);
        }

        [Test]
        public void CreateComposedComponent()
        {
            // Erstellen des Katalogs
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            // Erstellen des Containers zur Komposition
            var container = new CompositionContainer(catalog);

            var l = container.GetExport<ConnectorUsingByConstructor>();

            l.Value.Connector.SayHello(Console.Out);
        }

        [Test]
        public void UseMultipleComponents()
        {
            // Erstellung des Kataloges
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            Lazy<IApplicationExtension> implExtension = null;

            // Auflisten aller exportierten Komponenten eines bestimmten Vertrages
            foreach(var l in container.GetExports<IApplicationExtension>())
            {
                if (implExtension == null)
                    implExtension = l;
                
                l.Value.SayHello(Console.Out);



            }

            // Erstellung einer Komponente, die eine Vertragsimplementierung nutzt
            var objExtensionHost = new ExtensionHost();


            CompositionBatch batch = new CompositionBatch();

            container.ComposeParts();
            
            container.SatisfyImportsOnce(objExtensionHost);

            if (objExtensionHost.Extension != null)
                objExtensionHost.Extension.SayHello(Console.Out);
            else
                Console.WriteLine("Es konnte keine Erweiterung ermittelt werden.");
        }


    }
}
