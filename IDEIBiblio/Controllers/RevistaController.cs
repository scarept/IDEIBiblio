using System;
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
    public class RevistaController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Revista/

        public ActionResult Index()
        {
            
            
            List<Revista> revista_list = new List<Revista>();
            var produtos = db.produtos.ToList();
            foreach (var p in produtos)
            {
                var entityType = ObjectContext.GetObjectType(p.GetType());
                Revista r = new Revista();
                if (entityType == ObjectContext.GetObjectType(r.GetType()))
                {
                    r = (Revista)p;
                    revista_list.Add(r);
                }

            }
            IEnumerable<Revista> ret_revistas= revista_list;
            return View(ret_revistas);
        }

        //
        // GET: /Revista/Details/5

        public ActionResult Details(int id = 0)
        {
            Revista revista = null;
            try
            {
                revista = (Revista)db.produtos.Find(id);
            }
            catch (InvalidCastException e)
            {}
            
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        //
        // GET: /Revista/Create

        public ActionResult Create()
        {
            CategoriasDropDownList();
            return View();
        }

        //
        // POST: /Revista/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "titulo,editora,preco,numero,edição,país,tipo_publicação,categoria")]Revista revista, string categoriaSelecionada)
        {
            try
            {
                Cat_Revista tmp = db.Categorias_Revistas.Find(Convert.ToInt32(categoriaSelecionada));
                revista.categoria = tmp;
            }
            catch (Exception e) { }
            if (ModelState.IsValid)
            {
                db.produtos.Add(revista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CategoriasDropDownList();
            return View(revista);
        }

        //
        // GET: /Revista/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Revista revista = (Revista)db.produtos.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            CategoriasDropDownList();
            return View(revista);
        }

        //
        // POST: /Revista/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Revista revista, string categoriaSelecionada)
        {
            try
            {
                Cat_Revista tmp = db.Categorias_Revistas.Find(Convert.ToInt32(categoriaSelecionada));
                revista.categoria = null;
                revista.categoria = tmp;
            }
            catch (Exception e) { }
            if (ModelState.IsValid)
            {
                db.Entry(revista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(revista);
        }

        //
        // GET: /Revista/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Revista revista = (Revista)db.produtos.Find(id);
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        //
        // POST: /Revista/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revista revista = (Revista)db.produtos.Find(id);
            db.produtos.Remove(revista);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private void CategoriasDropDownList(object selectedCategorias = null)
        {
            var categoriasQuery = from d in db.Categorias_Revistas
                                  orderby d.nome
                                  select d;
            var selectList = new SelectList(categoriasQuery, "ID", "nome", selectedCategorias);
            ViewBag.categoria = selectList;
        } 
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}