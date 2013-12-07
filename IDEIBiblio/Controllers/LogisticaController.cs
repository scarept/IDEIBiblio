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
    public class LogisticaController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Logistica/

        public ActionResult Index()
        {
            return View(db.logisticas.ToList());
        }

        //
        // GET: /Logistica/Details/5

        public ActionResult Details(int id = 0)
        {
            Logistica logistica = db.logisticas.Find(id);
            if (logistica == null)
            {
                return HttpNotFound();
            }
            return View(logistica);
        }

        //
        // GET: /Logistica/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Logistica/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Logistica logistica)
        {
            if (ModelState.IsValid)
            {
                db.logisticas.Add(logistica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logistica);
        }

        //
        // GET: /Logistica/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Logistica logistica = db.logisticas.Find(id);
            if (logistica == null)
            {
                return HttpNotFound();
            }
            return View(logistica);
        }

        //
        // POST: /Logistica/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Logistica logistica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logistica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logistica);
        }

        //
        // GET: /Logistica/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Logistica logistica = db.logisticas.Find(id);
            if (logistica == null)
            {
                return HttpNotFound();
            }
            return View(logistica);
        }

        //
        // POST: /Logistica/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logistica logistica = db.logisticas.Find(id);
            db.logisticas.Remove(logistica);
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