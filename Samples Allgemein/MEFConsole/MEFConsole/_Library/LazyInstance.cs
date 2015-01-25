using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MEFConsole
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export("LazyInstancing")]
    [ExportMetadata("Test", "Dasdfasf  asdfasdf")]
    public class LazyInstance
    {
        private static int msv_intLazyInstance;
        private readonly int mv_intMyInstanceId = 0;

        public LazyInstance()
        {
            mv_intMyInstanceId = System.Threading.Interlocked.Increment(ref msv_intLazyInstance);

            Console.WriteLine("Constructor");
        }

        public int InstanceId
        {
            get { return mv_intMyInstanceId; }
        }
    }


}
