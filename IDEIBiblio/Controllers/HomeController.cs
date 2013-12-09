using IDEIBiblio.Dal;
using IDEIBiblio.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDEIBiblio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Widget()
        {
            ViewBag.Message = "Widget";

            return View();
        }

        public ActionResult E404(){
            return View();
        }
        public ActionResult E403()
        {
            return View();
        }

    }
}
