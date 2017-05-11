using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace SelfhostingWebAPI.CustomServices
{
    public class InfoOnlyHttpActionSelector : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            var action = base.SelectAction(controllerContext);

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {typeof(IHttpActionSelector).Name}.{MethodBase.GetCurrentMethod().Name}()");

            if (action != null)
            {
                Debug.WriteLine($"\tactiondescriptor: {action.ActionName}, returns {action.ReturnType?.Name}");
            }

            return action;
        }

        public override ILookup<string, HttpActionDescriptor> GetActionMapping(HttpControllerDescriptor controllerDescriptor)
        {
            var mapping = base.GetActionMapping(controllerDescriptor);

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {typeof(IHttpActionSelector).Name}.{MethodBase.GetCurrentMethod().Name}()");
            
            return mapping;
        }
    }
}
