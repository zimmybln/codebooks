using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContainerApplication.Components
{
    public class CustomRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var defaultroutehandler = base.GetHttpHandler(requestContext);

            Debug.WriteLine($"GetHttpHandler: {requestContext.HttpContext.Request.Path} causes {defaultroutehandler.GetType().Name}");
            
            return defaultroutehandler;
        }
    }
}