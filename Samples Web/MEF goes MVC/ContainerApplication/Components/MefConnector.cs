using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Web;

namespace ContainerApplication.Components
{
    public class MefConnector
    {
        private static CompositionContainer CompositionContainer;
        private static bool IsLoaded = false;

        public static void Compose(List<string> extensionFolders)
        {
            if (IsLoaded) return;

            var catalog = new AggregateCatalog();

            // Aktuelles Bin-Verzeichnis zum Katalog hinzufügen. Damit können Teile der Containeranwendung Bestandteile
            // des Katalogs sein
            catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin")));
            
            foreach (var extension in extensionFolders)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extensions", extension);


                var directoryCatalog = new DirectoryCatalog(path);
                catalog.Catalogs.Add(directoryCatalog);

                // Falls es in dem Verzeichnis der Erweiterung noch ein Bin-Verzeichnis gibt, nehmen wir das auch noch mit
                var binpath = Path.Combine(path, "bin");

                if (Directory.Exists(binpath))
                {
                    var bindirectoryCatalog = new DirectoryCatalog(binpath);
                    catalog.Catalogs.Add(bindirectoryCatalog);
                }

            }

            CompositionContainer = new CompositionContainer(catalog);

            CompositionContainer.ComposeParts();
            IsLoaded = true;
        }

        public static T GetInstance<T>(string contractName = null)
        {

            var type = default(T);

            if (CompositionContainer == null) return type;

            try
            {
                if (!string.IsNullOrWhiteSpace(contractName))
                    type = CompositionContainer.GetExportedValue<T>(contractName);
                else
                    type = CompositionContainer.GetExportedValue<T>();
            }
            catch (Exception)
            {
                
            }


            return type;
        }
    }
}