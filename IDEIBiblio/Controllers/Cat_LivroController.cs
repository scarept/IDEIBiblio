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
    public class Cat_LivroController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Cat_Livro/

        public ActionResult Index()
        {
            return View(db.Categorias_Livros.ToList());
        }

        //
        // GET: /Cat_Livro/Details/5

        public ActionResult Details(int id = 0)
        {
            Cat_Livro cat_livro = db.Categorias_Livros.Find(id);
            if (cat_livro == null)
            {
                return HttpNotFound();
            }
            return View(cat_livro);
        }

        //
        // GET: /Cat_Livro/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cat_Livro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cat_Livro cat_livro)
        {
            if (ModelState.IsValid)
            {
                db.Categorias_Livros.Add(cat_livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat_livro);
        }

        //
        // GET: /Cat_Livro/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cat_Livro cat_livro = db.Categorias_Livros.Find(id);
            if (cat_livro == null)
            {
                return HttpNotFound();
            }
            return View(cat_livro);
        }

        //
        // POST: /Cat_Livro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cat_Livro cat_livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat_livro);
        }

        //
        // GET: /Cat_Livro/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cat_Livro cat_livro = db.Categorias_Livros.Find(id);
            if (cat_livro == null)
            {
                return HttpNotFound();
            }
            return View(cat_livro);
        }

        //
        // POST: /Cat_Livro/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat_Livro cat_livro = db.Categorias_Livros.Find(id);
            db.Categorias_Livros.Remove(cat_livro);
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