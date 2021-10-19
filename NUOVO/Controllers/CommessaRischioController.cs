using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NUOVO.DAL;
using NUOVO.Models;
using System.Globalization;
using System.Threading;

namespace NUOVO.Controllers
{
    [Authorize]
    public class CommessaRischioController : Controller
    {
        private Context db = new Context();

        // GET: CommessaRischio
        public ActionResult Index()
        {
            var commessaRischios = db.CommessaRischio.Include(c => c.Commessa);
            return View(commessaRischios.ToList());
        }

        // GET: CommessaRischio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommessaRischio commessaRischio = db.CommessaRischio.SingleOrDefault(m => m.Progressivo == id);
            if (commessaRischio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommessaID = db.Commessa.SingleOrDefault(m => m.CommessaID == commessaRischio.CommessaID).Descrizione;
            return View(commessaRischio);
        }

        // GET: CommessaRischio/Create
        public ActionResult Create()
        {

            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione");
            return View();
        }

        // POST: CommessaRischio/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NomeRischio,Progressivo,CommessaID,DataRilevamento,DataAggiornamento,Voto,Priorita,Importo,Probabilita,Impatto,Strategia")] CommessaRischio commessaRischio)
        {
            if (ModelState.IsValid)
            {
                db.CommessaRischio.Add(commessaRischio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione", commessaRischio.CommessaID);
            return View(commessaRischio);
        }

        // GET: CommessaRischio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommessaRischio commessaRischio = db.CommessaRischio.SingleOrDefault(m => m.Progressivo == id);
            if (commessaRischio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione", commessaRischio.CommessaID);
            return View(commessaRischio);
        }

        // POST: CommessaRischio/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NomeRischio,Progressivo,CommessaID,DataRilevamento,DataAggiornamento,Voto,Priorita,Importo,Probabilita,Impatto,Strategia")] CommessaRischio commessaRischio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commessaRischio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione", commessaRischio.CommessaID);
            return View(commessaRischio);
        }

        // GET: CommessaRischio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommessaRischio commessaRischio = db.CommessaRischio.SingleOrDefault(m => m.Progressivo == id);
            if (commessaRischio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommessaID = db.Commessa.SingleOrDefault(m => m.CommessaID == commessaRischio.CommessaID).Descrizione;
            return View(commessaRischio);
        }

        // POST: CommessaRischio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommessaRischio commessaRischio = db.CommessaRischio.SingleOrDefault(m => m.Progressivo == id);
            ViewBag.CommessaID = db.Commessa.SingleOrDefault(m => m.CommessaID == commessaRischio.CommessaID).Descrizione;
            db.CommessaRischio.Remove(commessaRischio);
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
