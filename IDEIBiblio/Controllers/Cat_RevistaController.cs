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
    public class Cat_RevistaController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Cat_Revista/
        [Authorize(Roles = "Administrador,Gestor")]
        public ActionResult Index()
        {
            return View(db.Categorias_Revistas.ToList());
        }

        //
        // GET: /Cat_Revista/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Cat_Revista cat_revista = db.Categorias_Revistas.Find(id);
        //    if (cat_revista == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cat_revista);
        //}

        //
        // GET: /Cat_Revista/Create
        [Authorize(Roles = "Administrador,Gestor")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cat_Revista/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cat_Revista cat_revista)
        {
            if (ModelState.IsValid)
            {
                db.Categorias_Revistas.Add(cat_revista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat_revista);
        }

        //
        // GET: /Cat_Revista/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Cat_Revista cat_revista = db.Categorias_Revistas.Find(id);
        //    if (cat_revista == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cat_revista);
        //}

        //
        // POST: /Cat_Revista/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Cat_Revista cat_revista)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cat_revista).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(cat_revista);
        //}

        //
        // GET: /Cat_Revista/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Cat_Revista cat_revista = db.Categorias_Revistas.Find(id);
        //    if (cat_revista == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cat_revista);
        //}

        //
        // POST: /Cat_Revista/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Cat_Revista cat_revista = db.Categorias_Revistas.Find(id);
        //    db.Categorias_Revistas.Remove(cat_revista);
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