using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace SelfhostingWebAPI.CustomServices
{
    public class InfoOnlyHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IHttpControllerActivator _embeddedControllerActivator;

        public InfoOnlyHttpControllerActivator()
        {
            _embeddedControllerActivator = new DefaultHttpControllerActivator();
        }


        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = _embeddedControllerActivator.Create(request, controllerDescriptor, controllerType);

            Debug.WriteLine($"{GlobalCounter.GetGlobalCounter():00000}: {typeof(IHttpControllerActivator).Name}.{MethodBase.GetCurrentMethod().Name}()");

            if (controller != null)
            {
                Debug.WriteLine($"\tControllerinstanz: {controller.GetType().FullName}");
            }

            return controller;
        }
    }
}
