using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.Dal;
using IDEIBiblio.Filters;
using WebMatrix.WebData;
using System.Web.Security;

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
        [InitializeSimpleMembership]
        public ActionResult Create(Administrador administrador, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegisterModel reg_model_tmp = new RegisterModel();
                    reg_model_tmp.UserName = collection.Get("reg_mod.UserName");
                    reg_model_tmp.Password = collection.Get("reg_mod.Password");
                    reg_model_tmp.ConfirmPassword = collection.Get("reg_mod.ConfirmPassword");
                    WebSecurity.CreateUserAndAccount(reg_model_tmp.UserName, reg_model_tmp.Password);
                    WebSecurity.Login(reg_model_tmp.UserName, reg_model_tmp.Password);
                    int id = WebSecurity.GetUserId(reg_model_tmp.UserName);
                    administrador.profile = id;
                    Roles.AddUserToRole(reg_model_tmp.UserName, "Administrador");
                    
                }
                if (ModelState.IsValid)
                {
                    db.Administradors.Add(administrador);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ClassesLog.Log.GetLogger().Error(e);
                return View(administrador);
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

        public Administrador ObterAdministradorAutenticado()
        {
            try
            {
                int id_login;
                if (WebSecurity.Initialized)
                {
                    id_login = WebSecurity.CurrentUserId;
                }
                else
                {
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                    id_login = WebSecurity.CurrentUserId;
                }
                var administrador = from d in db.Administradors where d.profile == id_login select d;
                List<IDEIBiblio.Models.Administrador> tempList = administrador.ToList();
                IDEIBiblio.Models.Administrador tmpAdmi = tempList.ElementAt(0);
                return tmpAdmi;
            }
            catch (Exception e)
            {
                ClassesLog.Log.GetLogger().Error(e);
                return null;
            }

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}