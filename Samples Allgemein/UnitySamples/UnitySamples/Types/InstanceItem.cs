using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitySamples.Types
{
    public class InstanceItem
    {
        public InstanceItem()
        {
            Console.WriteLine($".ctor {this.GetHashCode()}");
        }


        public int Counter { get; set; }

    }
}
