using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UnitySamples.Types
{
    public class ComposeableItem
    {
        private TextWriter _writer;
        
        public ComposeableItem(TextWriter writer)
        {
            _writer = writer;
        }


        public void SayHello()
        {
            _writer.WriteLine($"Die Ausgabe erfolgt mit Hilfe von {_writer.GetType().Name}");
        }
    }
}
