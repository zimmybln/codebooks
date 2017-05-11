using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitySamples.Types
{
    public class BusEntity : IEntity
    {
        public string GetName()
        {
            return this.GetType().Name;
        }
    }
}
