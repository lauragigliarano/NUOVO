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

namespace NUOVO.Controllers
{
    [Authorize]
    public class CommessaStackholderController : Controller
    {
        private Context db = new Context();

        // GET: CommessaStackholder
        public ActionResult Index()
        {
            var commessaStackholders = db.CommessaStackholders.Include(c => c.Commessa).Include(c => c.Stackholder);
            return View(commessaStackholders.ToList());
        }

        // GET: CommessaStackholder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Find(id);
            if (commessaStackholder == null)
            {
                return HttpNotFound();
            }
            return View(commessaStackholder);
        }

        // GET: CommessaStackholder/Create
        public ActionResult Create()
        {
            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione");
            ViewBag.StackholderID = new SelectList(db.Stackholder, "StackholderID", "Nome");
            return View();
        }

        // POST: CommessaStackholder/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumeroRilevamentoID,CommessaID,StackholderID,DataRilevamento,Interesse,Potere,Impatto,Note")] CommessaStackholder commessaStackholder)
        {
            if (ModelState.IsValid)
            {
                db.CommessaStackholders.Add(commessaStackholder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione", commessaStackholder.CommessaID);
            ViewBag.StackholderID = new SelectList(db.Stackholder, "StackholderID", "Nome", commessaStackholder.StackholderID);
            return View(commessaStackholder);
        }

        // GET: CommessaStackholder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Find(id);
            if (commessaStackholder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione", commessaStackholder.CommessaID);
            ViewBag.StackholderID = new SelectList(db.Stackholder, "StackholderID", "Nome", commessaStackholder.StackholderID);
            return View(commessaStackholder);
        }

        // POST: CommessaStackholder/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumeroRilevamentoID,CommessaID,StackholderID,DataRilevamento,Interesse,Potere,Impatto,Note")] CommessaStackholder commessaStackholder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commessaStackholder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione", commessaStackholder.CommessaID);
            ViewBag.StackholderID = new SelectList(db.Stackholder, "StackholderID", "Nome", commessaStackholder.StackholderID);
            return View(commessaStackholder);
        }

        // GET: CommessaStackholder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Find(id);
            if (commessaStackholder == null)
            {
                return HttpNotFound();
            }
            return View(commessaStackholder);
        }

        // POST: CommessaStackholder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Find(id);
            db.CommessaStackholders.Remove(commessaStackholder);
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
        public JsonResult GetNumeroRilevamento(int CommessaID, int StackholderID)
        {
            int numero;
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Where(q => q.CommessaID == CommessaID && q.StackholderID == StackholderID).OrderByDescending(q => q.NumeroRilevamentoID).FirstOrDefault();
            if (commessaStackholder != null)
            {
                numero = commessaStackholder.NumeroRilevamentoID + 1;
            }
            else numero = 1;
            return Json(new { numero });
        }

        [HttpPost]
        public JsonResult SetDataOdierna(int CommessaID, int StackholderID)
        {
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Where(q => q.CommessaID == CommessaID && q.StackholderID == StackholderID).OrderByDescending(q => q.NumeroRilevamentoID).FirstOrDefault();
            int giorno = DateTime.Now.Day;
            int mese = DateTime.Now.Month;
            int anno = DateTime.Now.Year;

            return Json(new { giorno, mese, anno });
        }

    }
}
