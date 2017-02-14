using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace SelfhostingWebAPI.CustomServices
{
    public class CustomHttpControllerSelector : DefaultHttpControllerSelector
    {
        public CustomHttpControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
            
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
           
            Debug.WriteLine("SelectController");

            return base.SelectController(request);
        }
    }
}
