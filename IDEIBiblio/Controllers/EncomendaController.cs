using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.Dal;
using IDEIBiblio.Comunications;

namespace IDEIBiblio.Controllers
{
    public class EncomendaController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Encomenda/
         [Authorize(Roles = "Administrador,Cliente")]
        public ActionResult Index()
        {
            AccountController ctrAc = new AccountController();
            string userType = ctrAc.GetUserType();
            if (userType == "Cliente")
            {
                ClienteController ctrCli = new ClienteController();
                Cliente auth = ctrCli.ObterClienteAutenticado();
                var encomendaQuery = from d in db.Encomendas
                                  where d.cliente.ID == auth.ID
                                     select d;
                
                return View(encomendaQuery.ToList());
            }
                        
            return View(db.Encomendas.ToList());
        }

        //
        // GET: /Encomenda/Details/5
        [Authorize(Roles = "Cliente,Administrador")]
        public ActionResult Details(int id = 0)
        {
            Encomenda encomenda = db.Encomendas.Find(id);
            AccountController ctrAc = new AccountController();
            string userType = ctrAc.GetUserType();
            if (userType == "Cliente")
            {
                ClienteController ctrCli = new ClienteController();
                Cliente auth = ctrCli.ObterClienteAutenticado();
                if (auth.ID != encomenda.cliente.ID)
                {
                    return RedirectToAction("Index", "Home");

                }
                if (encomenda == null)
                {
                    return HttpNotFound();
                }
                return View(encomenda);
            }
            else
            {
                if (encomenda == null)
                {
                    return HttpNotFound();
                }
                return View(encomenda);
            }

        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Validar(int id = 0)
        {
            try
            {
                Encomenda enco = db.Encomendas.Find(id);
                Compra compra = new Compra();
                compra.data = DateTime.Now;
                compra.total = enco.Get_Total();
                compra.cliente = enco.cliente;
                compra.fatura = new Fatura(enco);
                string mail = enco.cliente.email;
                db.Compras.Add(compra);
                db.Encomendas.Remove(enco);
                db.SaveChanges();
                MailController ctrMail = new MailController();
                ctrMail.sendMail(mail, "Encomenda Processada", "A sua encomenda com o nº. " + enco.EncomendaID + " já foi processada.\n <a href=\"http://localhost:53958/Fatura/Details/" + compra.fatura.ID + "\">Fatura</a>");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ClassesLog.Log.GetLogger().Error(e);
                return RedirectToAction("Details/"+id, "Encomenda");
            }

        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Remover(int id = 0)
        {
            try{
                Encomenda enco = db.Encomendas.Find(id);
                enco.linhas = new List<Linha_Doc>();
                db.Entry(enco).State = EntityState.Modified;
                db.SaveChanges();
                db.Encomendas.Remove(enco);
                db.SaveChanges();
                return RedirectToAction("Index", "Encomenda");
            }catch(Exception e){
                ClassesLog.Log.GetLogger().Error(e);
                return RedirectToAction("Details/"+id, "Encomenda");
            }
 
        }

        public ActionResult RemoverLinha(FormCollection collection)
        {
            int idEncomenda = Convert.ToInt32(collection.Get("ID"));
            int idLinha = Convert.ToInt32(collection.Get("idL"));
            Linha_Doc linha = db.Linhas_Faturas.Find(idLinha);
            try
            {
                db.Linhas_Faturas.Remove(linha);
                db.SaveChanges();
                return RedirectToAction("Details/" + idEncomenda, "Encomenda");
            }
            catch(Exception e)
            {
                ClassesLog.Log.GetLogger().Error(e);
                return RedirectToAction("Details/" + idEncomenda, "Encomenda");
            }
      
        }
        ////
        //// GET: /Encomenda/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Encomenda/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Encomenda encomenda)
        //{
        //    encomenda.data = DateTime.Now;
        //    if (ModelState.IsValid)
        //    {
        //        db.Encomendas.Add(encomenda);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(encomenda);
        //}

        ////
        //// GET: /Encomenda/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Encomenda encomenda = db.Encomendas.Find(id);
        //    if (encomenda == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(encomenda);
        //}

        ////
        //// POST: /Encomenda/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Encomenda encomenda)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(encomenda).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(encomenda);
        //}

        ////
        //// GET: /Encomenda/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Encomenda encomenda = db.Encomendas.Find(id);
        //    if (encomenda == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(encomenda);
        //}

        ////
        //// POST: /Encomenda/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Encomenda encomenda = db.Encomendas.Find(id);
        //    db.Encomendas.Remove(encomenda);
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