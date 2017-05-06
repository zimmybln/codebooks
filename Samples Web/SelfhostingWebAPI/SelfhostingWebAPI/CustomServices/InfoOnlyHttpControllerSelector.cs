using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace SelfhostingWebAPI.CustomServices
{
    public class InfoOnlyHttpControllerSelector : DefaultHttpControllerSelector
    {
        public InfoOnlyHttpControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var httpcontrollerdescriptor = base.SelectController(request);

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {typeof(IHttpControllerSelector).Name}.{MethodBase.GetCurrentMethod().Name}()");

            Debug.WriteLine($"\t{request.RequestUri}");

            if (httpcontrollerdescriptor != null)
            {
                Debug.WriteLine($"\tControllertype: {httpcontrollerdescriptor.ControllerType.Name + " (" + httpcontrollerdescriptor.ControllerType.FullName + ")"}");
            }

            return httpcontrollerdescriptor;
        }

        public override string GetControllerName(HttpRequestMessage request)
        {
            var name = base.GetControllerName(request);

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {typeof(IHttpControllerSelector).Name}.{MethodBase.GetCurrentMethod().Name}()");

            Debug.WriteLine($"\tControllername: {name}");

            return name;
        }

        public override IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            var mapping = base.GetControllerMapping();

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {typeof(IHttpControllerSelector).Name}.{MethodBase.GetCurrentMethod().Name}()");
            
            return mapping;
        }
    }
}
