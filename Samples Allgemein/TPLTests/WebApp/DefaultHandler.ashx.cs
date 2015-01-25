using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebApp
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für DefaultHandler
    /// </summary>
    public class DefaultHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(String.Format("Aktuelle Zeit: {0}", DateTime.Now.ToString()));
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