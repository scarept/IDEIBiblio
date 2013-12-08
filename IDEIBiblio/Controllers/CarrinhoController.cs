using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.Dal;
using WebMatrix.WebData;

namespace IDEIBiblio.Controllers
{
    public class CarrinhoController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Carrinho/

        //public ActionResult Index()
        //{
        //    return View(db.carrinhos.ToList());
        //}

        //
        // GET: /Carrinho/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Carrinho carrinho = db.carrinhos.Find(id);
        //    if (carrinho == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(carrinho);
        //}

        //
        // GET: /Carrinho/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Carrinho/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Carrinho carrinho)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.carrinhos.Add(carrinho);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(carrinho);
        //}

        //
        // GET: /Carrinho/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Carrinho carrinho = db.carrinhos.Find(id);
            if (carrinho == null)
            {
                return HttpNotFound();
            }
            return View(carrinho);
        }

        //
        // POST: /Carrinho/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Carrinho carrinho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrinho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrinho);
        }

        //
        // GET: /Carrinho/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Carrinho carrinho = db.carrinhos.Find(id);
            if (carrinho == null)
            {
                return HttpNotFound();
            }
            return View(carrinho);
        }

        //
        // POST: /Carrinho/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrinho carrinho = db.carrinhos.Find(id);
            db.carrinhos.Remove(carrinho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult AddToCart(FormCollection collection)
        {
            int id = Convert.ToInt32(collection.Get("ID"));
            int qtd = Convert.ToInt32(collection.Get("validate.inteiro"));

            DataContext db = new DataContext();
            Produto p = db.produtos.Find(id);

            int id_login = WebSecurity.CurrentUserId;
            var cliente = from d in db.Cliente where d.profile == id_login select d;
            List<IDEIBiblio.Models.Cliente> tempList = cliente.ToList();
            IDEIBiblio.Models.Cliente tmpClie = tempList.ElementAt(0);

            tmpClie.carrinho.AdicionarAoCarrinho(p, qtd);

            if (ModelState.IsValid)
            {
                db.Entry(tmpClie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit/"+tmpClie.carrinho.ID,"Carrinho");
            }
                return RedirectToAction("Edit/"+tmpClie.carrinho.ID,"Carrinho");
        }

        public ActionResult RemoverItem(int id)
        {
            Item_Carrinho item = db.items_carrinho.Find(id);
            try
            {
                db.items_carrinho.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Edit/"+id, "Carrinho");
            }
            catch
            {
                return RedirectToAction("Edit/"+id, "Carrinho");
            }
            
            return null;
        }
        [HttpPost, ActionName("Bridge")]
        public ActionResult Bridge(int id)
        {
            return Redirect("/Carrinho/Edit/"+id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(int id)
        {
            Carrinho cart = db.carrinhos.Find(id);
            IList<Logistica> logisticas = db.logisticas.ToList();
            float menor = 999999999;
            int idMenor = 0;

            foreach (Logistica l in logisticas)
            {
                float portes = l.CalculaPortes(cart.linhas);
                if (portes < menor)
                {
                    menor = portes;
                    idMenor = l.ID;
                }
            }
            ViewBag.portes = menor;
            ViewBag.logistica = idMenor;
            return View(cart);

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckoutValidated(FormCollection collection)
        {
           try
            {
                int id_login = WebSecurity.CurrentUserId;
                var cliente = from d in db.Cliente where d.profile == id_login select d;
                List<IDEIBiblio.Models.Cliente> tempList = cliente.ToList();
                IDEIBiblio.Models.Cliente tmpClie = tempList.ElementAt(0);
                Carrinho carro = tmpClie.carrinho;
                int logisticaID = Convert.ToInt32(collection.Get("Logistica"));
                Logistica logi = db.logisticas.Find(logisticaID);

                Encomenda encomenda = new Encomenda(carro, tmpClie,logi);

                
                float portes = (float)Convert.ToDouble(collection.Get("Portes"));
                encomenda.Portes = portes;
                carro.resetItemsCarrino();
                db.Entry(tmpClie).State = EntityState.Modified;
                db.Encomendas.Add(encomenda);
                db.SaveChanges();
                return RedirectToAction("Index","Home");

            }
            catch (Exception)
            {
                return RedirectToAction("Edit/" + collection.Get("ID"), "Carrinho");
            }
        }

    }
}