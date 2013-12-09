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
    public class FaturaController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Fatura/

        //public ActionResult Index()
        //{
        //    return View(db.Faturas.ToList());
        //}

        //
        // GET: /Fatura/Details/5
        [Authorize(Roles="Cliente,Administrador")]
        public ActionResult Details(int id = 0)
        {
            Fatura fatura = db.Faturas.Find(id);
            AccountController ctrAcc = new AccountController();
            string userType = ctrAcc.GetUserType();
            if (userType == "Cliente")
            {
                ClienteController ctrCli = new ClienteController();
                Cliente auth = ctrCli.ObterClienteAutenticado();
                var compraQuery = from d in db.Compras
                                      where d.fatura.ID == fatura.ID
                                      select d;
                Compra compra = compraQuery.ToList().ElementAt(0);
                if (auth.ID != compra.cliente.ID)
                {
                    return RedirectToAction("Index", "Home");

                }
                if (fatura == null)
                {
                    return HttpNotFound();
                }
                return View(fatura);
            }
            
            if (fatura == null)
            {
                return HttpNotFound();
            }
            return View(fatura);
        }
        
        //
        // GET: /Fatura/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Fatura/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Fatura fatura)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Faturas.Add(fatura);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(fatura);
        //}

        ////
        //// GET: /Fatura/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Fatura fatura = db.Faturas.Find(id);
        //    if (fatura == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fatura);
        //}

        ////
        //// POST: /Fatura/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Fatura fatura)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(fatura).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(fatura);
        //}

        ////
        //// GET: /Fatura/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Fatura fatura = db.Faturas.Find(id);
        //    if (fatura == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(fatura);
        //}

        ////
        //// POST: /Fatura/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Fatura fatura = db.Faturas.Find(id);
        //    db.Faturas.Remove(fatura);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}