using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
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

            ConfigureFormatters(webApiConfiguration);

            // Use the extension method provided by the WebApi.Owin library:
            app.UseWebApi(webApiConfiguration);
        }

        private void ConfigureRoutes(HttpConfiguration configuration)
        {
            //configuration.Routes.MapHttpRoute(
            //    "DefaultApi",
            //    "api/{controller}/",
            //    new {action = RouteParameter.Optional});

            //configuration.Routes.MapHttpRoute(
            //    "SecondApi",
            //    "api/{controller}/{filter}/",
            //    null);

            configuration.MapHttpAttributeRoutes();

            //configuration.Routes.MapHttpRoute(
            //    "FilterApi",
            //    "api/{controller}/{action}/{filter}",
            //    new { action = RouteParameter.Optional });

            //configuration.Routes.MapHttpRoute(
            //    "Api #2",
            //    "api/{controller}/{action}/{id}",
            //    new {id = RouteParameter.Optional});
        }

        private void ConfigureComponents(HttpConfiguration configuration)
        {
            configuration.Services.Replace(typeof(IAssembliesResolver), new InfoOnlyAssemblyResolver());
            configuration.Services.Replace(typeof(IHttpControllerSelector), new InfoOnlyHttpControllerSelector(configuration));
            configuration.Services.Replace(typeof(IHttpControllerTypeResolver), new InfoOnlyHttpControllerTypeResolver());
            configuration.Services.Replace(typeof(IHttpControllerActivator), new InfoOnlyHttpControllerActivator());
            configuration.Services.Replace(typeof(IHttpActionSelector), new InfoOnlyHttpActionSelector());
            configuration.Services.Replace(typeof(IHttpActionInvoker), new InfoOnlyHttpActionInvoker());
            configuration.Services.Replace(typeof(IApiExplorer), new InfoOnlyApiExplorer(configuration));
        }

        private void ConfigureFormatters(HttpConfiguration configuration)
        {
            //var appXmlType = configuration.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");

            //if (appXmlType != null)
            //    configuration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            
            //configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
