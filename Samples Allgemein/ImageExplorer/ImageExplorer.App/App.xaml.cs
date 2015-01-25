using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;

using ImageExplorer.Base;

namespace ImageExplorer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ImageExplorerApplication : Application
    {
        private CompositionContainer mv_objCompositionContainer;
        private IApplicationController mv_objApplicationController;
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Erstellung der Kataloge
            var catalog = new AggregateCatalog();
            
            // Laden der anwendungsspezifischen Assemblies
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.LoadFrom("ImageExplorer.Applications.dll")));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.LoadFrom("ImageExplorer.Presentation.dll")));

            // Erstellung des Containers für die Zusammenstellung
            mv_objCompositionContainer = new CompositionContainer(catalog);

            // Abarbeitung der Zusammenstellung
            var batch = new CompositionBatch();
            batch.AddExportedValue(mv_objCompositionContainer);
            mv_objCompositionContainer.Compose(batch);

            // Anwendungscontroller ermitteln und ausführen
            mv_objApplicationController = mv_objCompositionContainer.GetExportedValue<IApplicationController>();

            // Hier werden die Parameter der Befehlszeile übergeben
            mv_objApplicationController.Initialize(e.Args);
            mv_objApplicationController.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Aufräumarbeiten
            mv_objApplicationController.Shutdown();
            mv_objCompositionContainer.Dispose();

            base.OnExit(e);
        }

    }
}
