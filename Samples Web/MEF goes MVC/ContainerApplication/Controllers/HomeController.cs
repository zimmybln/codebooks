using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContainerApplication.Components;

namespace ContainerApplication.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Test = "Das ist ein Test, den wir für eine Teilansicht durchführen";

            string requestid = "keine Daten vorhanden";

            if (HttpContext.Items.Contains("SharedData"))
            {
                SharedDataBag databag = HttpContext.Items["SharedData"] as SharedDataBag;

                if (databag != null)
                {
                    requestid = databag.Id;
                }
            }

            ViewBag.RequestId = requestid;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}