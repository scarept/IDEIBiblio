using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.Dal;
using System.Web.Security;
using WebMatrix.WebData;
using IDEIBiblio.Filters;

namespace IDEIBiblio.Controllers
{
    public class ClienteController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [InitializeSimpleMembership]
        public ActionResult Create(Cliente cliente, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegisterModel reg_model_tmp = new RegisterModel();
                    reg_model_tmp.UserName = collection.Get("reg_mod.UserName");
                    reg_model_tmp.Password = collection.Get("reg_mod.Password");
                    reg_model_tmp.ConfirmPassword = collection.Get("reg_mod.ConfirmPassword");
                    //AccountController act_ctr = new AccountController();
                    //act_ctr.Register(reg_model_tmp);
                    WebSecurity.CreateUserAndAccount(reg_model_tmp.UserName, reg_model_tmp.Password);
                    WebSecurity.Login(reg_model_tmp.UserName, reg_model_tmp.Password);
                    int id = WebSecurity.GetUserId(reg_model_tmp.UserName);
                    cliente.profile = id;
                    Roles.AddUserToRole(reg_model_tmp.UserName, "Cliente");
                    cliente.carrinho = new Carrinho();
                }
                if (ModelState.IsValid)
                {
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return View(cliente);
            }
                return View(cliente);
            
           
            
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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