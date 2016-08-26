using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using System.Web.Mvc.Html;
using ContainerApplication.Components;

namespace SecondPlugIn
{
    [Export("AdditionalController", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AdditionalController : Controller
    {
        public ActionResult DoSomething()
        {
            return new StringResult();
        }

        public ActionResult SampleView()
        {
            // Geteilte Daten ermitteln
            string requestid = "keine Daten vorhanden";

            if (HttpContext.Items.Contains("SharedData"))
            {
                SharedDataBag databag = HttpContext.Items["SharedData"] as SharedDataBag;

                if (databag != null)
                {
                    requestid = databag.Id;
                }
            }

            ViewBag.Message = $"Das ist eine Nachricht, die wir über den Controller {DateTime.Now} im Request {requestid} erzeugt haben ";

            return View();

        }

        public ActionResult ShowPartialView()
        {
            string requestid = "keine Daten vorhanden";

            if (HttpContext.Items.Contains("SharedData"))
            {
                SharedDataBag databag = HttpContext.Items["SharedData"] as SharedDataBag;

                if (databag != null)
                {
                    requestid = databag.Id;
                }
            }

            ViewBag.Message = $"Request {requestid}";

            return PartialView("SomePartialView");
        }
    }
}
