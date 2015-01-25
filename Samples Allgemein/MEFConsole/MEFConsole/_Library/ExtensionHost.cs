using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MEFConsole
{
    public class ExtensionHost
    {

        [Import(typeof(IApplicationExtension))]
        public IApplicationExtension Extension { get; set; }
    }
}
