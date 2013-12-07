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
    public class AdministradorController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Administrador/

        public ActionResult Index()
        {
            return View(db.Administradors.ToList());
        }

        //
        // GET: /Administrador/Details/5

        public ActionResult Details(int id = 0)
        {
            Administrador administrador = db.Administradors.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        //
        // GET: /Administrador/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrador/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Administradors.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrador);
        }

        //
        // GET: /Administrador/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Administrador administrador = db.Administradors.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        //
        // POST: /Administrador/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        //
        // GET: /Administrador/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Administrador administrador = db.Administradors.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        //
        // POST: /Administrador/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador administrador = db.Administradors.Find(id);
            db.Administradors.Remove(administrador);
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