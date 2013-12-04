﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.Dal;
using System.Data.Objects;


namespace IDEIBiblio.Controllers
{
    public class LivroController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Livro/

        public ActionResult Index()
        {
          
           List<Livro> livros_list = new List<Livro>();
           var produtos = db.produtos.ToList();
           foreach (var p in produtos)
           {
              var entityType = ObjectContext.GetObjectType(p.GetType());
              Livro l = new Livro();
              if (entityType == ObjectContext.GetObjectType(l.GetType()))
              {
                  l = (Livro)p;
                  livros_list.Add(l);
              }
          
           }
           IEnumerable<Livro> ret_livros = livros_list;
 
          return View(ret_livros);
        }

        //
        // GET: /Livro/Details/5

        public ActionResult Details(int id = 0)
        {
            Livro livro = null;
            try
            {
                livro = (Livro)db.produtos.Find(id);
            }
            catch (InvalidCastException e) { }
           
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        //
        // GET: /Livro/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Livro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.produtos.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livro);
        }

        //
        // GET: /Livro/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Livro livro = (Livro)db.produtos.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        //
        // POST: /Livro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        //
        // GET: /Livro/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Livro livro = (Livro)db.produtos.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        //
        // POST: /Livro/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = (Livro)db.produtos.Find(id);
            db.produtos.Remove(livro);
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