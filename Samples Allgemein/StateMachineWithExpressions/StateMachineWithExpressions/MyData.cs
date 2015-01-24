using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithExpressions
{
    public interface IMyData
    {
        int i { get; set; }

        int j { get; set; }
    }


    public class MyData : IMyData
    {
        public int i { get; set; }

        public int j { get; set; }
    }
}
