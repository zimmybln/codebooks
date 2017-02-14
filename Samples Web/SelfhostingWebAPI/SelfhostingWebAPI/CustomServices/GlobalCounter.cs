using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Routing.Constraints;

namespace SelfhostingWebAPI.CustomServices
{
    public static class GlobalCounter
    {
        private static int _counter = 0;

        public static int GetGlobalCounter()
        {
            return Interlocked.Increment(ref _counter);
        }


    }
}
