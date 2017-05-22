using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pwlc.Models;

namespace pwlc.Controllers
{
    public class InjectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Injections
        public ActionResult Index()
        {
            return View(db.Injections.ToList());
        }

        // GET: Injections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injection injection = db.Injections.Find(id);
            if (injection == null)
            {
                return HttpNotFound();
            }
            return View(injection);
        }

        // GET: Injections/Create
        public ActionResult Create(string pid)
        {
            if (pid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Patient patient = db.Patients.Find(pid);
            Injection injection = new Injection();
            injection.Patient = patient;
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(injection);
        }

        // POST: Injections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Injection injection)
        {
            if (ModelState.IsValid)
            {
                injection.Patient = db.Patients.Find(injection.Patient.PatientId);
                db.Injections.Add(injection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(injection);
        }

        // GET: Injections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injection injection = db.Injections.Find(id);
            if (injection == null)
            {
                return HttpNotFound();
            }
            return View(injection);
        }

        // POST: Injections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InjectionId,InjectionDate,LotNumber,ExpDate,InjectionLocation")] Injection injection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(injection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(injection);
        }

        // GET: Injections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Injection injection = db.Injections.Find(id);
            if (injection == null)
            {
                return HttpNotFound();
            }
            return View(injection);
        }

        // POST: Injections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Injection injection = db.Injections.Find(id);
            db.Injections.Remove(injection);
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
