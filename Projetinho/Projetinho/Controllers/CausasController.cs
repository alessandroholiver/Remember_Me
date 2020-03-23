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
    public class CausasController : Controller
    {
        private AppDbContexto db = new AppDbContexto();

        // GET: Causas
        public ActionResult Index()
        {
            var causas = db.Causas.Include(c => c.Regra);
            return View(causas.ToList());
        }

        // GET: Causas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Causa causa = db.Causas.Find(id);
            if (causa == null)
            {
                return HttpNotFound();
            }
            return View(causa);
        }

        // GET: Causas/Create
        public ActionResult Create()
        {
            ViewBag.RegraID = new SelectList(db.Regras, "RegraID", "Nome");
            return View();
        }

        // POST: Causas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CausaID,RegraID,Nome,Pergunta,Resposta")] Causa causa)
        {
            if (ModelState.IsValid)
            {
                db.Causas.Add(causa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegraID = new SelectList(db.Regras, "RegraID", "Nome", causa.RegraID);
            return View(causa);
        }

        // GET: Causas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Causa causa = db.Causas.Find(id);
            if (causa == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegraID = new SelectList(db.Regras, "RegraID", "Nome", causa.RegraID);
            return View(causa);
        }

        // POST: Causas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CausaID,RegraID,Nome,Pergunta,Resposta")] Causa causa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(causa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegraID = new SelectList(db.Regras, "RegraID", "Nome", causa.RegraID);
            return View(causa);
        }

        // GET: Causas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Causa causa = db.Causas.Find(id);
            if (causa == null)
            {
                return HttpNotFound();
            }
            return View(causa);
        }

        // POST: Causas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Causa causa = db.Causas.Find(id);
            db.Causas.Remove(causa);
            db.SaveChanges();
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
