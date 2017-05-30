using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pwlc.Models;
using pwlc.Crypto;
using DYMO.Label.Framework;

namespace pwlc.Controllers
{
    public class PrescriptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prescriptions
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Index()
        {
            return View(db.Prescriptions.ToList());
        }

        // GET: Prescriptions/Details/5
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // GET: Prescriptions/Create
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Create(string pid, int cid)
        {
            if (pid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Patient patient = db.Patients.Find(pid);
            Checkup checkup = db.Checkups.Find(cid);
            Prescription prescription = new Prescription();
            prescription.Patient = patient;
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }


        // POST: Prescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prescription prescription, Patient patient, Checkup checkup)
        {
            if (ModelState.IsValid)
            {
                prescription.ScriptName = Encryptor.Encrypt(prescription.ScriptName);
                prescription.ScriptRx = Encryptor.Encrypt(prescription.ScriptRx);
                prescription.ScriptDirections = Encryptor.Encrypt(prescription.ScriptDirections);
                db.Prescriptions.Add(prescription);
                patient.Prescriptions.Add(prescription);
                db.SaveChanges();
                return RedirectToAction("Create", "Invoices", new { cid = checkup.CheckupId });
            }

            return View(prescription);
        }

        // GET: Prescriptions/Edit/5
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            prescription.ScriptName = Encryptor.Decrypt(prescription.ScriptName);
            prescription.ScriptRx = Encryptor.Decrypt(prescription.ScriptRx);
            prescription.ScriptDirections = Encryptor.Decrypt(prescription.ScriptDirections);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScriptId,ScriptName,ScriptRx,ScriptDirections")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                prescription.ScriptName = Encryptor.Encrypt(prescription.ScriptName);
                prescription.ScriptRx = Encryptor.Encrypt(prescription.ScriptRx);
                prescription.ScriptDirections = Encryptor.Encrypt(prescription.ScriptDirections);
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescription prescription = db.Prescriptions.Find(id);
            db.Prescriptions.Remove(prescription);
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

        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult ReviewLabelInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            prescription.ScriptName = Encryptor.Decrypt(prescription.ScriptName);
            prescription.ScriptRx = Encryptor.Decrypt(prescription.ScriptRx);
            prescription.ScriptDirections = Encryptor.Decrypt(prescription.ScriptDirections);
            prescription.Patient.Address = Encryptor.Decrypt(prescription.Patient.Address);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public void Print(int? id)
        {
            Prescription prescription = db.Prescriptions.Find(id);
            var today = DateTime.Today.ToString();
            var label = Label.Open(AppDomain.CurrentDomain.BaseDirectory + "Labels/PatientLabel.label");
            label.SetObjectText("lblName", prescription.Patient.FirstName + " " + prescription.Patient.LastName);
            label.SetObjectText("lblToday", today);
            label.SetObjectText("lblAddress", Encryptor.Decrypt(prescription.Patient.Address));
            label.SetObjectText("lblRxNum", "RX#" + Encryptor.Decrypt(prescription.ScriptRx));
            label.SetObjectText("lblAddres2", prescription.Patient.City + ", " + prescription.Patient.State + " " + prescription.Patient.Zip);
            label.SetObjectText("lblDob", prescription.Patient.DateOfBirth);
            label.SetObjectText("lblPrescription", Encryptor.Decrypt(prescription.ScriptName));
            label.SetObjectText("lblDirections", Encryptor.Decrypt(prescription.ScriptDirections));
            label.SetObjectText("lblRefill", "No Refills");
            label.Print("DYMO LabelWriter 450");
        }

    }
}
