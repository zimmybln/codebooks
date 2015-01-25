using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;

namespace MEFConsole
{

    [Export(typeof(IApplicationExtension))]
    [ExtensionInfo(ExtensionType.Client, Name = "Das ist die Bezeichnung für die zweite Erweiterung")]
    public class SecondExtension : IApplicationExtension
    {
        public void SayHello(TextWriter Out)
        {
            Out.WriteLine("Das ist eine Nachricht von der zweiten Erweiterung");
        }
    }
}
