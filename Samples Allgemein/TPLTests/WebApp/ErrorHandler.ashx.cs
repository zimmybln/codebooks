using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für ErrorHandler
    /// </summary>
    public class ErrorHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.AddError(new HttpException(404, "Item not found"));
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