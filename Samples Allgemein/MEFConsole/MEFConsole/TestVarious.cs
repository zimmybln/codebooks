using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MEFConsole
{
    [TestFixture]
    public class TestVarious
    {

        /*
         *      Metadaten
         *      http://codebetter.com/blogs/glenn.block/archive/2009/12/04/building-hello-mef-part-ii-metadata-and-why-being-lazy-is-a-good-thing.aspx
         *      http://blogs.microsoft.co.il/blogs/bnaya/archive/2010/01/20/mef-for-beginner-metadata-part-8.aspx
         * 
         * 
         */



        /// <summary>
        /// Listet alle Komponenten aus dem aktuellen Assembly auf, die 
        /// </summary>
        [Test]
        public void ListComponentsFromCatalog()
        {

            // Erstellung des Kataloges
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            // Auflisten aller exportierten Komponenten eines bestimmten Vertrages
            foreach(var l in container.GetExports<IApplicationExtension, IExtensionInfo>())
            {
                Console.WriteLine("Name: {0}, Erweiterungsart: {1}", l.Metadata.Name, l.Metadata.ExtensionType);
            }

        }

        [Test]
        [TestCase(ExtensionType.Server)]
        public void ListComponentsFromCatalogByProperty(ExtensionType ExtensionType)
        {
            // Erstellung des Kataloges
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var container = new CompositionContainer(catalog);

            var query = from e in container.GetExports<IApplicationExtension, IExtensionInfo>()
                        where e.Metadata.ExtensionType == ExtensionType
                        select e;

            foreach(var l in query)
            {
                Console.WriteLine(l.Metadata.Name);
            }

            Console.WriteLine("Anzahl der gefundenen Erweiterungen: {0}", query.Count());

        }

        [Test]
        public void InstanceLazyComponents()
        {
            var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());

            var firstcontainer = new CompositionContainer(catalog);

            var c1 = firstcontainer.GetExport<LazyInstance>("LazyInstancing");

            Console.WriteLine(c1.Value.InstanceId);
            Console.WriteLine(c1.Value.InstanceId);
            Console.WriteLine(c1.Value.InstanceId);

            var c2 = firstcontainer.GetExport<LazyInstance>("LazyInstancing");

            Console.WriteLine(c2.Value.InstanceId);
            Console.WriteLine(c2.Value.InstanceId);
            Console.WriteLine(c2.Value.InstanceId);


            var secondcontainer = new CompositionContainer(catalog);

            var c3 = secondcontainer.GetExport<LazyInstance>("LazyInstancing");

            Console.WriteLine(c3.Value.InstanceId);
            Console.WriteLine(c3.Value.InstanceId);
            Console.WriteLine(c3.Value.InstanceId);



        }



    }
}
