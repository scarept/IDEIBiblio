using IDEIBiblio.Dal;
using IDEIBiblio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDEIBiblio.Controllers
{
    public class AnalisaMercadosController : Controller
    {
        //
        // GET: /AnalisaMercados/

        public ActionResult Index()
        {
            IList<Produto> produtos = new List<Produto>();
            DataContext db = new DataContext();
            NSAnalisaMercados.serverAnalisaMercadosPortTypeClient proxy = new NSAnalisaMercados.serverAnalisaMercadosPortTypeClient();
            Produto p = db.produtos.Find(proxy.getUpdatePrice().ID);
            p.preco = proxy.getUpdatePrice().VALOR;
            if (ModelState.IsValid)
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }

    }
}
