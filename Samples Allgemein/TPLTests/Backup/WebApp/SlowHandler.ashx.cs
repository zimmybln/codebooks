using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebApp
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für SlowHandler
    /// </summary>
    public class SlowHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Thread.Sleep(5000);
            context.Response.ContentType = "text/plain";
            context.Response.Write("Verzögerte Ausführung beendet");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}