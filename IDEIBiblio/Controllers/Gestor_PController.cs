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

namespace IDEIBiblio.Controllers
{
    public class Gestor_PController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Gestor_P/

        public ActionResult Index()
        {
            return View(db.Gestores.ToList());
        }

        //
        // GET: /Gestor_P/Details/5

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

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gestor_P/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gestor_P gestor_p)
        {
            if (ModelState.IsValid)
            {
                db.Gestores.Add(gestor_p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gestor_p);
        }

        //
        // GET: /Gestor_P/Edit/5

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

        public ActionResult Delete(int id = 0)
        {
            Gestor_P gestor_p = db.Gestores.Find(id);
            if (gestor_p == null)
            {
                return HttpNotFound();
            }
            return View(gestor_p);
        }

        //
        // POST: /Gestor_P/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gestor_P gestor_p = db.Gestores.Find(id);
            db.Gestores.Remove(gestor_p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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