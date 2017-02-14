using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Owin;
using SelfhostingWebAPI.CustomServices;

namespace SelfhostingWebAPI
{
    public class StartupWithInfoOnlyServices
    {
        // This method is required by Katana:
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = new HttpConfiguration();

            ConfigureRoutes(webApiConfiguration);

            ConfigureComponents(webApiConfiguration);

            // Use the extension method provided by the WebApi.Owin library:
            app.UseWebApi(webApiConfiguration);
        }

        private void ConfigureRoutes(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{configuration}/{controller}/{id}",
                new { id = RouteParameter.Optional, configuration = "" });
        }

        private void ConfigureComponents(HttpConfiguration configuration)
        {
            configuration.Services.Replace(typeof(IAssembliesResolver), new InfoOnlyAssemblyResolver());
            configuration.Services.Replace(typeof(IHttpControllerSelector), new InfoOnlyHttpControllerSelector(configuration));
            configuration.Services.Replace(typeof(IHttpControllerTypeResolver), new InfoOnlyHttpControllerTypeResolver());

        }
    }
}
