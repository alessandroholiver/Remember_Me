using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projetinho.DAL;
using Projetinho.Models;

namespace Projetinho.Controllers
{
    public class RegrasController : Controller
    {
        private AppDbContexto db = new AppDbContexto();

        // GET: Regras
        public ActionResult Index()
        {
            var regras = db.Regras.Include(r => r.Objetivo);
            return View(regras.ToList());
        }

        // GET: Regras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regra regra = db.Regras.Find(id);
            if (regra == null)
            {
                return HttpNotFound();
            }
            return View(regra);
        }

        // GET: Regras/Create
        public ActionResult Create()
        {
            ViewBag.ObjetivoID = new SelectList(db.Objetivos, "ObjetivoID", "Nome");
            return View();
        }

        // POST: Regras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ObjetivoID,Nome")] Regra regra)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Regras.Add(regra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            

           
            return View(regra);
        }

        // GET: Regras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regra regra = db.Regras.Find(id);
            if (regra == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObjetivoID = new SelectList(db.Objetivos, "ObjetivoID", "Nome", regra.ObjetivoID);
            return View(regra);
        }

        // POST: Regras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var regraToUpdate = db.Regras.Find(id);
            if (TryUpdateModel(regraToUpdate, "",
               new string[] { "Nome", "ObjetivoID" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(regraToUpdate);
        }

        // GET: Regras/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Regra regra = db.Regras.Find(id);
            if (regra == null)
            {
                return HttpNotFound();
            }
            return View(regra);
        }
        // POST: Regras/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Regra regra = db.Regras.Find(id);
                db.Regras.Remove(regra);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
