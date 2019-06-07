using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Pshh who needs to add a description to their page??";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Matt Washington.";

            return View();
        }
    }
}