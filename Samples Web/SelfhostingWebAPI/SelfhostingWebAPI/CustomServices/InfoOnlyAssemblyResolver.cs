using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace SelfhostingWebAPI.CustomServices
{
    public class InfoOnlyAssemblyResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            var assemblies = base.GetAssemblies();

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {this.GetType().Name}.{MethodBase.GetCurrentMethod().Name}()");

            Debug.WriteLine($"\t{String.Join("\r\n\t", assemblies.Select(asm => asm.GetName().Name))}");

            return assemblies;
        }
    }
}
