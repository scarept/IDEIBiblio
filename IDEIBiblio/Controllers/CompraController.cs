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
    public class CompraController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Compra/
        [Authorize(Roles="Administrador,Cliente")]
        public ActionResult Index()
        {
            IList<Compra> compras = db.Compras.ToList();
            return View(db.Compras.ToList());
        }

        //
        // GET: /Compra/Details/5
        [Authorize(Roles = "Administrador,Cliente")]
        public ActionResult Details(int id = 0)
        {
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        //
        // GET: /Compra/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Compra/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Compra compra)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Compras.Add(compra);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(compra);
        //}

        ////
        //// GET: /Compra/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Compra compra = db.Compras.Find(id);
        //    if (compra == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(compra);
        //}

        ////
        //// POST: /Compra/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Compra compra)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(compra).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(compra);
        //}

        ////
        //// GET: /Compra/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Compra compra = db.Compras.Find(id);
        //    if (compra == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(compra);
        //}

        ////
        //// POST: /Compra/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Compra compra = db.Compras.Find(id);
        //    db.Compras.Remove(compra);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}