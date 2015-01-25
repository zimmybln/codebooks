using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;

namespace MEFConsole
{
    [Export(typeof(IApplicationExtension))]
    [ExtensionInfo(ExtensionType.Server, Name="Das ist die Bezeichnung für die erste Erweiterung")]
    public class FirstExtension : IApplicationExtension
    {
        public void SayHello(TextWriter Out)
        {
            Out.WriteLine("Das ist die Nachricht von der ersten Erweiterung");

        }
    }
}
