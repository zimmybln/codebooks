using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseTheRightVersion.MetaDescription
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AlternativeTypeAttribute : Attribute
    {
        public AlternativeTypeAttribute(Type t)
        {
            AlternativeType = t;
        }

        public Type AlternativeType { get; private set; }
    }
}
