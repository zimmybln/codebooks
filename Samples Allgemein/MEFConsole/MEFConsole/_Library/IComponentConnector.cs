using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MEFConsole
{
    public interface IComponentConnector
    {
        void SayHello(TextWriter Out);
    }
}
