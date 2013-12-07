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
            ViewBag.Message = "Listagem de produtos";
            DataContext contexto = new IDEIBiblio.Dal.DataContext();
            List<IDEIBiblio.Models.Livro> allProds = contexto.Livroes.ToList();
            List<IDEIBiblio.Models.Livro> prod = new List<IDEIBiblio.Models.Livro>();
            if (allProds.Count() > 4)
            {
                prod.Add(allProds.ElementAt(allProds.Count()-1));
                prod.Add(allProds.ElementAt(allProds.Count() - 2));
                prod.Add(allProds.ElementAt(allProds.Count() - 3));
                prod.Add(allProds.ElementAt(allProds.Count() - 4));

            }
            else
            {
                prod = allProds;
            }
            return View(prod);
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
    }
}
