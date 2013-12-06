using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.Dal;

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

        public void AddToCart(Carrinho carro, Produto prod, int quant)
        {
            carro.AdicionarAoCarrinho(prod, quant);
        }

        public void Checkout(Carrinho carro)
        {
            Encomenda enco = new Encomenda();

        }
    }
}