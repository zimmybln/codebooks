using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MEFConsole
{
    public class ExtensionHostWithMany
    {
        [ImportMany(typeof(IApplicationExtension))]
        public IEnumerable<IApplicationExtension> Extensions { get; set; }
    }
}
