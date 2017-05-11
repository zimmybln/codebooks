using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseTheRightVersion
{
    public class MyComponent
    {
        public virtual string GetName()
        {
            return this.GetType().Name;
        }

    }
}
