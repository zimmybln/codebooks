using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ContainerApplication.Components;

namespace ThirdPlugIn
{
    [Export("ThirdPlugInController", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ThirdPlugInController : Controller
    {
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



            ViewBag.Message = $"{this.GetType().Assembly.GetName().Name}: Das ist eine Nachricht, die wir über den Controller {DateTime.Now} im Request {requestid} erzeugt haben ";

            return View();

        }
    }
}
