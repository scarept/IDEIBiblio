﻿using System;
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
    public class EncomendaController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Encomenda/

        public ActionResult Index()
        {
            return View(db.Encomendas.ToList());
        }

        //
        // GET: /Encomenda/Details/5

        public ActionResult Details(int id = 0)
        {
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        //
        // GET: /Encomenda/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Encomenda/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Encomenda encomenda)
        {
            encomenda.data = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Encomendas.Add(encomenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encomenda);
        }

        //
        // GET: /Encomenda/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        //
        // POST: /Encomenda/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Encomenda encomenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encomenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encomenda);
        }

        //
        // GET: /Encomenda/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Encomenda encomenda = db.Encomendas.Find(id);
            if (encomenda == null)
            {
                return HttpNotFound();
            }
            return View(encomenda);
        }

        //
        // POST: /Encomenda/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encomenda encomenda = db.Encomendas.Find(id);
            db.Encomendas.Remove(encomenda);
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