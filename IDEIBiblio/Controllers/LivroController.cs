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
using System.IO;


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
            CategoriasDropDownList();
            return View();
        }

        //
        // POST: /Livro/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "titulo,editora,preço,isbn,publicação,sinopse,path_img")]Livro livro, string categoriaSelecionada, HttpPostedFileBase file)
        {
            // Colocação da categoria no livro
            try
            {
                Cat_Livro tmp = db.Categorias_Livros.Find(Convert.ToInt32(categoriaSelecionada));
                livro.categoria = tmp;
            }catch (Exception e) { }

            // Colocação da imagem no livro
            if (file != null)
            {
                string pic = livro.isbn.ToString() + System.IO.Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Images/Livros/"), pic);
                
                file.SaveAs(path);
                livro.path_img = "Images/Livros/"+pic;
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            
            if (ModelState.IsValid)
            {                
                db.produtos.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CategoriasDropDownList(livro.categoria);
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

        private void CategoriasDropDownList(object selectedCategorias = null)
        {
            var categoriasQuery = from d in db.Categorias_Livros
                                  orderby d.nome
                                  select d;
            //ViewBag.categoria = new SelectList(categoriasQuery, "ID", "nome", selectedCategorias);
            //ViewData["myList"] = new SelectList(categoriasQuery, "ID", "nome", selectedCategorias);
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