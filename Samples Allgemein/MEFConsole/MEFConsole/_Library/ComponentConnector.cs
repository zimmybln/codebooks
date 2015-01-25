using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;

namespace MEFConsole
{
    [Export(typeof(IComponentConnector))]
    public class ComponentConnector : IComponentConnector
    {
        public void SayHello(TextWriter Out)
        {
            Out.WriteLine("Das ist durch die Komponente {0}", this.GetType().Name);
        }
    }
}
