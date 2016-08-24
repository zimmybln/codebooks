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
            ViewBag.Message = $"Das ist eine Nachricht, die wir über den Controller {DateTime.Now} erzeugt haben ";

            return View();

        }

        public ActionResult ShowPartialView()
        {
            return PartialView("SomePartialView");
        }
    }
}
