using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace SelfhostingWebAPI.CustomServices
{
    public class InfoOnlyHttpActionInvoker : ApiControllerActionInvoker
    {
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var task = base.InvokeActionAsync(actionContext, cancellationToken);

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {typeof(IHttpActionInvoker).Name}.{MethodBase.GetCurrentMethod().Name}()");

            return task;
        }
    }
}
