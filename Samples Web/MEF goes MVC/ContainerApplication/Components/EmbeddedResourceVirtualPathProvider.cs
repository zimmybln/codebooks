using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace ContainerApplication.Components
{
    public class EmbeddedResourceVirtualPathProvider : VirtualPathProvider
    {
        public EmbeddedResourceVirtualPathProvider()
        {

        }

        private bool IsEmbeddedResourcePath(string virtualPath)
        {
            var checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
            return checkPath.StartsWith("~/Succeed.Web/", StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool FileExists(string virtualPath)
        {
            return IsEmbeddedResourcePath(virtualPath) || base.FileExists(virtualPath);
        }

        /// <summary>
        /// Ermittelt die virtuelle Datei.
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns></returns>
        public override VirtualFile GetFile(string virtualPath)
        {
            if (IsEmbeddedResourcePath(virtualPath))
            {
                return new EmbeddedResourceFile(virtualPath);
            }
            else
            {
                return base.GetFile(virtualPath);
            }
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (IsEmbeddedResourcePath(virtualPath))
            {
                return null;
            }
            else
            {
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }
        }
    }
}