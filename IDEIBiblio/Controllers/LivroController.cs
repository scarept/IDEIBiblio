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
using System.IO;


namespace IDEIBiblio.Controllers
{
    public class LivroController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Livro/
        
        //public ActionResult Index()
        //{
          
        //   List<Livro> livros_list = new List<Livro>();
        //   var produtos = db.produtos.ToList();
        //   foreach (var p in produtos)
        //   {
        //      var entityType = ObjectContext.GetObjectType(p.GetType());
        //      Livro l = new Livro();
        //      if (entityType == ObjectContext.GetObjectType(l.GetType()))
        //      {
        //          l = (Livro)p;
        //          livros_list.Add(l);
        //      }
          
        //   }
        //   IEnumerable<Livro> ret_livros = livros_list;
 
        //  return View(ret_livros);
        //}

        //
        // GET: /Livro/Details/5
        [Authorize(Roles = "Gestor")]
        public ActionResult Details(int id = 0)
        {
            Livro livro = null;
            try
            {
                livro = (Livro)db.produtos.Find(id);
            }
            catch (InvalidCastException e) { ClassesLog.Log.GetLogger().Error(e); }
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        //
        // GET: /Livro/Create
        [Authorize(Roles = "Gestor")]
        public ActionResult Create()
        {
            CategoriasDropDownList();
            return View();
        }

        //
        // POST: /Livro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "titulo,editora,preco,isbn,publicação,sinopse,path_img")]Livro livro, string categoriaSelecionada, HttpPostedFileBase file)
        {
            // Colocação da categoria no livro
            try
            {
                Cat_Livro tmp = db.Categorias_Livros.Find(Convert.ToInt32(categoriaSelecionada));
                livro.categoria = tmp;
            }
            catch (Exception e) { ClassesLog.Log.GetLogger().Error(e); }

            // Colocação da imagem no livro
            if (file != null)
            {
                string pic = livro.isbn.ToString() + System.IO.Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Images/Livros/"), pic);
                
                file.SaveAs(path);
                livro.path_img = "Images/Livros/"+pic;
            }
            //Gestor_PController ctrGest = new Gestor_PController();
            //Gestor_P gest = ctrGest.ObterGestor_PAutenticado();
            ////livro.gestor_produto = gest;
           
            if (ModelState.IsValid)
            {
                db.produtos.Add(livro);
                db.SaveChanges();
                db.SaveChanges();
               
                return RedirectToAction("Index","Home");
            }
            CategoriasDropDownList(livro.categoria);
            return View(livro);
        }

        //
        // GET: /Livro/Edit/5
        [Authorize(Roles = "Gestor")]
        public ActionResult Edit(int id = 0)
        {
            Livro livro = (Livro)db.produtos.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            CategoriasDropDownList();
            return View(livro);
        }

        //
        // POST: /Livro/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro livro, string categoriaSelecionada, HttpPostedFileBase file)
        {
            try
            {
                Cat_Livro tmp = db.Categorias_Livros.Find(Convert.ToInt32(categoriaSelecionada));
                livro.categoria = null;
                livro.categoria = tmp;
            }
            catch (Exception e) { ClassesLog.Log.GetLogger().Error(e); }

            // Colocação da imagem no livro
            if (file != null)
            {
                string pic = livro.isbn.ToString() + System.IO.Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Images/Livros/"), pic);

                file.SaveAs(path);
                livro.path_img = "Images/Livros/" + pic;
                //// save the image path path to the database or you can send image 
                //// directly to database
                //// in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}

            }
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(livro);
        }

        //
        // GET: /Livro/Delete/5
        [Authorize(Roles = "Gestor,Administrador")]
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

        private void CategoriasDropDownList(object selectedCategorias = null)
        {
            var categoriasQuery = from d in db.Categorias_Livros
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

        public ActionResult ListarTodos()
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
        // GET: /Livro/ListarCategoria
        public ActionResult ListarCategoria()
        {
            //List<Cat_Livro> cat_livros_list = new List<Cat_Livro>();
            //var lista_categorias = db.Categorias_Livros.ToList();
            
            //IEnumerable<Cat_Livro> cat_livros = cat_livros_list;
            CategoriasDropDownList();
            return View();
        }

        //
        // POST: /Livro/listarCategoria

        [HttpPost, ActionName("ListarCategoria")]
        [ValidateAntiForgeryToken]
        public ActionResult ListarCategoria(string categoriaSelecionada)
        {
            try
            {
                Cat_Livro tmp = db.Categorias_Livros.Find(Convert.ToInt32(categoriaSelecionada));
                ListarPorCategorias(tmp);
            }
            catch (Exception e) { ClassesLog.Log.GetLogger().Error(e); }
            CategoriasDropDownList();
            return View();
        }

        private void ListarPorCategorias(Cat_Livro cat)
        {
            var livroscategoriaQuery = from d in db.Livroes where d.categoria.ID == cat.ID select d;
            List<IDEIBiblio.Models.Livro> lista = livroscategoriaQuery.ToList();
            
            ViewBag.listaLivrosCategoria = lista;
        } 


        //
        // GET: /Livro/PesquisarISBN
        public ActionResult PesquisarISBN()
        {
            return View();
        }

        //
        // POST: /Livro/PesquisarISBN
        [HttpPost, ActionName("PesquisarISBN")]
        [ValidateAntiForgeryToken]
        public ActionResult PesquisarISBN(FormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection.Get("isbn"));
                var query = from d in db.Livroes where d.isbn == id select d;
                List<IDEIBiblio.Models.Livro> lista = query.ToList();

                ViewBag.livros = lista;

               return View();
            }
            catch (Exception e)
            {
                return View();
            }
            
        }
        [Authorize(Roles = "Gestor,Administrador")]
        public ActionResult ListarEliminar()
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
        [Authorize(Roles = "Gestor,Administrador")]
        public ActionResult ListarEditar()
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

    }
}