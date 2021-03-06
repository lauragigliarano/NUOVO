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

        [HttpPost]
        public JsonResult SetDataOdierna()
        {
            string giorno = DateTime.Now.Day.ToString();
            string mese = DateTime.Now.Month.ToString();
            string anno = DateTime.Now.Year.ToString();

            if (DateTime.Now.Month < 10)
            {
                mese = "0" + mese;
            }

            if (DateTime.Now.Day < 10)
            {
                giorno = "0" + giorno;
            }

            return Json(new { giorno, mese, anno });
        }

        [HttpPost]
        public JsonResult SetData(int numero, int commessa )
        {
            CommessaRischio rischio = db.CommessaRischio.Where(q => q.Progressivo == numero && q.CommessaID == commessa).FirstOrDefault();
            string giornoR = rischio.DataRilevamento.Day.ToString();
            string meseR = rischio.DataRilevamento.Month.ToString();
            string annoR = rischio.DataRilevamento.Year.ToString();

            if (rischio.DataRilevamento.Month < 10)
            {
                meseR = "0" + meseR;
            }

            if (rischio.DataRilevamento.Day < 10)
            {
                giornoR = "0" + giornoR;
            }

            return Json(new { giornoR, meseR, annoR });
        }


        [HttpPost]
        public JsonResult GetNumeroRilevamento(int CommessaID)
        {
            int numero;
            CommessaRischio rischio = db.CommessaRischio.Where(q => q.CommessaID == CommessaID).OrderByDescending(q => q.Progressivo).FirstOrDefault();
            if (rischio != null)
            {
                numero = rischio.Progressivo + 1;
            }
            else numero = 1;
            return Json(new { numero });
        }
    }
}
