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
    public class Gestor_PController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Gestor_P/

        public ActionResult Index()
        {
            return View(db.Gestores.ToList());
        }

        //
        // GET: /Gestor_P/Details/5

        public ActionResult Details(int id = 0)
        {
            Gestor_P gestor_p = db.Gestores.Find(id);
            if (gestor_p == null)
            {
                return HttpNotFound();
            }
            return View(gestor_p);
        }

        //
        // GET: /Gestor_P/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gestor_P/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gestor_P gestor_p)
        {
            if (ModelState.IsValid)
            {
                db.Gestores.Add(gestor_p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gestor_p);
        }

        //
        // GET: /Gestor_P/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gestor_P gestor_p = db.Gestores.Find(id);
            if (gestor_p == null)
            {
                return HttpNotFound();
            }
            return View(gestor_p);
        }

        //
        // POST: /Gestor_P/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gestor_P gestor_p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestor_p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gestor_p);
        }

        //
        // GET: /Gestor_P/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gestor_P gestor_p = db.Gestores.Find(id);
            if (gestor_p == null)
            {
                return HttpNotFound();
            }
            return View(gestor_p);
        }

        //
        // POST: /Gestor_P/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gestor_P gestor_p = db.Gestores.Find(id);
            db.Gestores.Remove(gestor_p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}