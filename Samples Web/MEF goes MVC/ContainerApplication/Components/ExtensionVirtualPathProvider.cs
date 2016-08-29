using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace ContainerApplication.Components
{
    public class ExtensionVirtualPathProvider : VirtualPathProvider
    {
        private bool IsExtensionResourcePath(string virtualPath)
        {
            var checkPath = VirtualPathUtility.ToAppRelative(virtualPath);

            var pathsegments = checkPath.Split('/');

            if (pathsegments.Length != 3)
                return false;

            var controllername = pathsegments[1];

            var assemblyfile = MefConnector.GetControllerAssemblyFile(controllername);

            if (String.IsNullOrEmpty(assemblyfile))
                return false;
            
            return true;
        }

        private string VirtualPathToVirtualFile(string virtualPath)
        {
            var checkPath = VirtualPathUtility.ToAppRelative(virtualPath);

            var pathsegments = checkPath.Split('/');

            if (pathsegments.Length != 3)
                return null;

            var controllername = pathsegments[1];
            var viewfile = pathsegments[2];

            var assemblyfile = MefConnector.GetControllerAssemblyFile(controllername);

            if (String.IsNullOrEmpty(assemblyfile))
                return null;

            var filename = Path.Combine(Path.GetDirectoryName(assemblyfile), "Views", viewfile, ".cshtml");

            if (File.Exists(filename))
                return filename;

            return null;
        }

        public override bool FileExists(string virtualPath)
        {
            var fileexists = IsExtensionResourcePath(virtualPath) || base.FileExists(virtualPath);

            Debug.WriteLine($"FileExists: {virtualPath}:{fileexists}");

            return fileexists;
        }

        public override VirtualDirectory GetDirectory(string virtualDir)
        {
            return base.GetDirectory(virtualDir);
        }

        /// <summary>
        /// Ermittelt die virtuelle Datei.
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public override VirtualFile GetFile(string virtualPath)
        {
            Debug.WriteLine($"GetFile: {virtualPath}");

            if (IsExtensionResourcePath(virtualPath))
            {
                var file = VirtualPathToVirtualFile(virtualPath);

                return new EmbeddedResourceFile(file);
            }
            else
            {
                return base.GetFile(virtualPath);
            }
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsExtensionResourcePath(virtualPath))
            {
                return null;
            }
            else
            {
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }
        }

        private bool IsVirtualPath(string virtualPath)
        {
            var path = (VirtualPathUtility.GetDirectory(virtualPath) != "~/") ? VirtualPathUtility.RemoveTrailingSlash(VirtualPathUtility.GetDirectory(virtualPath)) : VirtualPathUtility.GetDirectory(virtualPath);
            if (path.Equals("~/Views/Routing", StringComparison.OrdinalIgnoreCase) || path.Equals("/Views/Routing", StringComparison.OrdinalIgnoreCase))
                return true;
            else
                return false;
        }
    }
}