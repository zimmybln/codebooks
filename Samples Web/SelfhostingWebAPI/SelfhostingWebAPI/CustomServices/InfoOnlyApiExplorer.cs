using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace SelfhostingWebAPI.CustomServices
{
    public class InfoOnlyApiExplorer : ApiExplorer
    {
        public InfoOnlyApiExplorer(HttpConfiguration configuration) : base(configuration)
        {

        }

        public override Collection<HttpMethod> GetHttpMethodsSupportedByAction(IHttpRoute route, HttpActionDescriptor actionDescriptor)
        {
            var methods = base.GetHttpMethodsSupportedByAction(route, actionDescriptor);

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {typeof(IApiExplorer).Name}.{MethodBase.GetCurrentMethod().Name}()");

            return methods;
        }

        public override bool ShouldExploreAction(string actionVariableValue, HttpActionDescriptor actionDescriptor, IHttpRoute route)
        {
            var shouldexplore = base.ShouldExploreAction(actionVariableValue, actionDescriptor, route);

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {typeof(IApiExplorer).Name}.{MethodBase.GetCurrentMethod().Name}()");

            return shouldexplore;
        }
    }
}
