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
    public class RevistaController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Revista/

        //public ActionResult Index()
        //{
            
            
        //    List<Revista> revista_list = new List<Revista>();
        //    var produtos = db.produtos.ToList();
        //    foreach (var p in produtos)
        //    {
        //        var entityType = ObjectContext.GetObjectType(p.GetType());
        //        Revista r = new Revista();
        //        if (entityType == ObjectContext.GetObjectType(r.GetType()))
        //        {
        //            r = (Revista)p;
        //            revista_list.Add(r);
        //        }

        //    }
        //    IEnumerable<Revista> ret_revistas= revista_list;
        //    return View(ret_revistas);
        //}

        //
        // GET: /Revista/Details/5
        [Authorize(Roles = "Gestor")]
        public ActionResult Details(int id = 0)
        {
            Revista revista = null;
            try
            {
                revista = (Revista)db.produtos.Find(id);
            }
            catch (InvalidCastException e)
            { ClassesLog.Log.GetLogger().Error(e); }
            
            if (revista == null)
            {
                return HttpNotFound();
            }
            return View(revista);
        }

        //
        // GET: /Revista/Create
        [Authorize(Roles = "Gestor")]
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
            catch (Exception e) { ClassesLog.Log.GetLogger().Error(e); }
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
        [Authorize(Roles = "Gestor")]
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
            catch (Exception e) { ClassesLog.Log.GetLogger().Error(e); }
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
        [Authorize(Roles = "Gestor,Administrador")]
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


        //
        // GET: /Revista/ListarCategoria
        public ActionResult ListarCategoria()
        {
           
            CategoriasDropDownList();
            return View();
        }

        //
        // POST: /Revista/ListarCategoria

        [HttpPost, ActionName("ListarCategoria")]
        [ValidateAntiForgeryToken]
        public ActionResult ListarCategoria(string categoriaSelecionada)
        {
            try
            {
                Cat_Revista tmp = db.Categorias_Revistas.Find(Convert.ToInt32(categoriaSelecionada));
                ListarPorCategorias(tmp);
            }
            catch (Exception e) { ClassesLog.Log.GetLogger().Error(e); }
            CategoriasDropDownList();
            return View();
        }

        private void ListarPorCategorias(Cat_Revista cat)
        {
            var revistacategoriaQuery = from d in db.Revistas where d.categoria.ID == cat.ID select d;
            List<IDEIBiblio.Models.Revista> lista = revistacategoriaQuery.ToList();

            ViewBag.listaRevistaCategoria = lista;
        }

        public ActionResult ListarTodos()
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
            IEnumerable<Revista> ret_revistas = revista_list;
            return View(ret_revistas);
        }
        [Authorize(Roles = "Gestor,Administrador")]
        public ActionResult ListarEliminar()
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
            IEnumerable<Revista> ret_revistas = revista_list;
            return View(ret_revistas);
        }
        [Authorize(Roles = "Gestor,Administrador")]
        public ActionResult ListarEditar()
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
            IEnumerable<Revista> ret_revistas = revista_list;
            return View(ret_revistas);
        }
    }
}