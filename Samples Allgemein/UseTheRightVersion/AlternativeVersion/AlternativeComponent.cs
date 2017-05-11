using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseTheRightVersion;
using UseTheRightVersion.MetaDescription;

namespace AlternativeVersion
{
    [AlternativeType(typeof(MyComponent))]
    public class AlternativeComponent : MyComponent
    {
        public override string GetName()
        {
            return "Alternative Implementierung " + base.GetName();
        }
    }
}
