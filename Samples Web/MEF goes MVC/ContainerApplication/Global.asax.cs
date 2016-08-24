using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ContainerApplication.Components;

namespace ContainerApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var extensionFolders = new List<string>();

            var extensions = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extensions")).ToList();

            // Von den Erweiterungen heben wir uns nur den Namen der Verzeichnisse auf
            extensions.ForEach(s =>
            {
                var di = new DirectoryInfo(s);
                extensionFolders.Add(di.Name);
            });
            
            // Das ist Standardverhalten
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Hier wird der Mef-Katalog erstellt
            MefConnector.Compose(extensionFolders);
            
            // Hier wird die alternative Controllerfactory gesetzt. Diese sorgt dafür, dass aus den Webanfragen ~/Controller/Action
            // konkrete Aufrufe an die Controller erfolgen.
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());

            ViewEngines.Engines.Add(new CustomViewEngine(extensionFolders));

            // Das benötigen wir für die Weiterentwicklung, dass mehrere Erweiterungen die gleichen Viewnamen haben können
            // System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new EmbeddedResourceVirtualPathProvider());

            
        }
    }
}
