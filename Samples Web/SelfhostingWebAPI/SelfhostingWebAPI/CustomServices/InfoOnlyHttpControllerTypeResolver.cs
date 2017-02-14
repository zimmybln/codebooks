using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace SelfhostingWebAPI.CustomServices
{
    public class InfoOnlyHttpControllerTypeResolver : DefaultHttpControllerTypeResolver
    {
        public override ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver)
        {
            var types = base.GetControllerTypes(assembliesResolver);

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {this.GetType().Name}.{MethodBase.GetCurrentMethod().Name}()");

            if (types != null)
            {
                Debug.WriteLine($"\t{String.Join("\r\n\t", types.Select(t => t.FullName))}");
            }
            
            return types;
        }
    }
}
