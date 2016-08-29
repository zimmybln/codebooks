using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContainerApplication.Components
{

    /// <summary>
    /// Diese Viewengine ergänzt die Orte für die Suche nach den Dateien der Views.
    /// </summary>
    /// <remarks>
    /// Die beiden Methoden GetViewLocationFormats und GetMasterLocationFormats setzen die Muster, wie die Dateien für die 
    /// jeweiligen Views gesucht werden.
    /// </remarks>
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine(List<string> extensionFolders)
        {
            ViewLocationFormats = GetViewLocationFormats(extensionFolders, ViewLocationFormats);
            MasterLocationFormats = GetMasterLocationFormats(extensionFolders, MasterLocationFormats);
            PartialViewLocationFormats = GetViewLocationFormats(extensionFolders, PartialViewLocationFormats);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var view = base.FindView(controllerContext, viewName, masterName, useCache);

            return view;
        }
        
        public string[] GetViewLocationFormats(List<string> extensionFolders, IEnumerable<string> defaultItems = null)
        {
            var views = new List<string>();

            if (defaultItems != null)
                views.AddRange(defaultItems);
          
            extensionFolders.ForEach(delegate(string plugin)
            {
                views.Add("~/Extensions/" + plugin + "/Views/{0}.cshtml");
                views.Add("~/Extensions/" + plugin + "/Views/{0}.vbhtml");
            });

            return views.ToArray();
        }

        public string[] GetMasterLocationFormats(List<string> extensionFolders, IEnumerable<string> defaultItems = null)
        {
            var masterPages = new List<string>();

            if (defaultItems != null)
                masterPages.AddRange(defaultItems);
            
            extensionFolders.ForEach(plugin =>
                masterPages.Add("~/Extensions/" + plugin + "/Views/Shared/{0}.cshtml")
            );

            return masterPages.ToArray();
        }
    }


}