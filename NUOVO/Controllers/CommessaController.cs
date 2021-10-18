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

   
    public class CommessaController : Controller
    {

        private Context db = new Context();

        // GET: Commessa
        public ActionResult Index()
        {
            var commessa = db.Commessa.Include(c => c.Cliente);
            return View(commessa.ToList());
        }

        // GET: Commessa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commessa commessa = db.Commessa.Find(id);
            if (commessa == null)
            {
                return HttpNotFound();
            }
            return View(commessa);
        }

        // GET: Commessa/Create
        public ActionResult Create()
        {
            Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
            // Creates and initializes the CultureInfo which uses the international sort.
            CultureInfo myCIintl = new CultureInfo("it-IT", false);
            Console.WriteLine("CurrentCulture is now {0}.", CultureInfo.CurrentCulture.Name);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "RagioneSociale");
            return View();
        }

        // POST: Commessa/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommessaID,Descrizione,ClienteID,DataInizio,DataFine,Importo")] Commessa commessa)
        {

            if (ModelState.IsValid)
            {
                db.Commessa.Add(commessa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "RagioneSociale", commessa.ClienteID);
            return View(commessa);
        }

        // GET: Commessa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commessa commessa = db.Commessa.Find(id);
            if (commessa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "RagioneSociale", commessa.ClienteID);
            return View(commessa);
        }

        // POST: Commessa/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommessaID,Descrizione,ClienteID,DataInizio,DataFine,Importo")] Commessa commessa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commessa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
            // Creates and initializes the CultureInfo which uses the international sort.
            CultureInfo myCIintl = new CultureInfo("it-IT", false);
            Console.WriteLine("CurrentCulture is now {0}.", CultureInfo.CurrentCulture.Name);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "RagioneSociale", commessa.ClienteID);
            return View(commessa);
        }

        // GET: Commessa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commessa commessa = db.Commessa.Find(id);
            if (commessa == null)
            {
                return HttpNotFound();
            }
            return View(commessa);
        }

        // POST: Commessa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commessa commessa = db.Commessa.Find(id);
            db.Commessa.Remove(commessa);
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
        public JsonResult CheckDataFine(DateTime inizio, DateTime fine)
        {
            int numero = DateTime.Compare(inizio, fine);

            return Json(new { numero });
        }
    }
}
