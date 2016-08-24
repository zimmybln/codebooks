using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace ContainerApplication.Components
{
    /// <summary>
    /// Mit dieser Klasse können Views geladen werden, die sich an anderen Orten als dem
    /// Verzeichnis Views befinden.
    /// </summary>
    public class EmbeddedResourceFile : VirtualFile
    {
        private string m_path;

        public EmbeddedResourceFile(string virtualPath)
            : base(virtualPath)
        {
            m_path = VirtualPathUtility.ToAppRelative(virtualPath);
        }

        public override System.IO.Stream Open()
        {
            var parts = m_path.Split('/');
            var assemblyName = parts[1];
            var resourceName = parts[2];

            assemblyName = Path.Combine(HttpRuntime.BinDirectory, assemblyName);
            var assembly = System.Reflection.Assembly.LoadFile(assemblyName + ".dll");

            if (assembly != null)
            {
                return assembly.GetManifestResourceStream(resourceName);
            }
            return null;
        }
    }
}