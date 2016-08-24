using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SecondPlugIn
{
    public class StringResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write("Das ist ein Test aus dem Assembly " + this.GetType().Assembly.FullName);
        }
    }
}
