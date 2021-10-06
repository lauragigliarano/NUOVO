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
    public class StackholderController : Controller
    {
        private Context db = new Context();

        // GET: Stackholder
        public ActionResult Index()
        {
            return View(db.Stackholder.ToList());
        }

        // GET: Stackholder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stackholder stackholder = db.Stackholder.Find(id);
            if (stackholder == null)
            {
                return HttpNotFound();
            }
            return View(stackholder);
        }

        // GET: Stackholder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stackholder/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StackholderID,Nome,Cognome,Telefono,Cellulare,Mail,Note")] Stackholder stackholder)
        {
            if (ModelState.IsValid)
            {
                db.Stackholder.Add(stackholder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stackholder);
        }

        // GET: Stackholder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stackholder stackholder = db.Stackholder.Find(id);
            if (stackholder == null)
            {
                return HttpNotFound();
            }
            return View(stackholder);
        }

        // POST: Stackholder/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StackholderID,Nome,Cognome,Telefono,Cellulare,Mail,Note")] Stackholder stackholder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stackholder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stackholder);
        }

        // GET: Stackholder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stackholder stackholder = db.Stackholder.Find(id);
            if (stackholder == null)
            {
                return HttpNotFound();
            }
            return View(stackholder);
        }

        // POST: Stackholder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stackholder stackholder = db.Stackholder.Find(id);
            db.Stackholder.Remove(stackholder);
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
