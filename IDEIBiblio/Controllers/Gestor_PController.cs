using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.Dal;
using WebMatrix.WebData;
using IDEIBiblio.Filters;
using System.Web.Security;

namespace IDEIBiblio.Controllers
{
    public class Gestor_PController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Gestor_P/
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Gestores.ToList());
        }

        //
        // GET: /Gestor_P/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int id = 0)
        {
            Gestor_P gestor_p = db.Gestores.Find(id);
            if (gestor_p == null)
            {
                return HttpNotFound();
            }
            return View(gestor_p);
        }

        //
        // GET: /Gestor_P/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gestor_P/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [InitializeSimpleMembership]
        public ActionResult Create(Gestor_P gestor, FormCollection collection)
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
                    WebSecurity.GetUserId(reg_model_tmp.UserName);
                    int id = WebSecurity.GetUserId(reg_model_tmp.UserName);
                    gestor.profile = id;
                    Roles.AddUserToRole(reg_model_tmp.UserName, "Gestor");

                }
                if (ModelState.IsValid)
                {
                    db.Gestores.Add(gestor);
                    db.SaveChanges();
                    return RedirectToAction("Index","Home");
                }
            }
            catch (Exception e)
            {
                ClassesLog.Log.GetLogger().Error(e);
                return View(gestor);
            }
            return View(gestor);
        }

        //
        // GET: /Gestor_P/Edit/5
         [Authorize(Roles = "Gestor")]
        public ActionResult Edit(int id = 0)
        {
            Gestor_P gestor_p = db.Gestores.Find(id);
            if (gestor_p == null)
            {
                return HttpNotFound();
            }
            return View(gestor_p);
        }

        //
        // POST: /Gestor_P/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gestor_P gestor_p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestor_p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gestor_p);
        }

        //
        // GET: /Gestor_P/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Gestor_P gestor_p = db.Gestores.Find(id);
        //    if (gestor_p == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gestor_p);
        //}

        //
        // POST: /Gestor_P/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Gestor_P gestor_p = db.Gestores.Find(id);
        //    db.Gestores.Remove(gestor_p);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public Gestor_P ObterGestor_PAutenticado()
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
                var gestor_p = from d in db.Gestores where d.profile == id_login select d;
                List<IDEIBiblio.Models.Gestor_P> tempList = gestor_p.ToList();
                IDEIBiblio.Models.Gestor_P tmpGest = tempList.ElementAt(0);
                return tmpGest;
            }
            catch (Exception e)
            {
                ClassesLog.Log.GetLogger().Error(e);
                return null;
            }

        }
    }
}