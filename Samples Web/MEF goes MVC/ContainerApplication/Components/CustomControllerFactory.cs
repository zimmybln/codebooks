using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ContainerApplication.Components
{
    /// <summary>
    /// Diese Controllerfactory erlaubt das Laden von Controllern aus den Erweiterungen. Wenn dort kein
    /// Controller mit dem gesuchten Namen gefunden wird, greift das Standardverhalten.
    /// </summary>
    public class CustomControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var name = controllerName;

            if (!name.EndsWith("Controller", StringComparison.InvariantCultureIgnoreCase))
                name += "Controller";
            
            var controller = MefConnector.GetInstance<IController>(name) ??
                             base.CreateController(requestContext, controllerName);

            return controller;
        }

    }
}