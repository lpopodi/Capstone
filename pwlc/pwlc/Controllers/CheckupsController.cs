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
    public class CheckupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checkups
        public ActionResult Index()
        {
            return View(db.Checkups.ToList());
        }

        // GET: Checkups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkup checkup = db.Checkups.Find(id);
            if (checkup == null)
            {
                return HttpNotFound();
            }
            return View(checkup);
        }

        // GET: Checkups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Checkups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CheckupId,CheckupDate,CheckupType,Age,Height,Weight,BP,BMI,BodyFat,LossGain,Amount,TotalLoss,DailyWaterIntake,Cycle,Excercising,FollowingFoodGuidelines,HCG,Hips,Waist,Chest,Arm,ScriptToFill,StaffNotes,DoctorNotes,Signature,FillScript")] Checkup checkup, string patientId)
        {
            if (ModelState.IsValid)
            {
                var patient = db.Patients.Where(i => i.PatientId == patientId).Select(p => p).FirstOrDefault();
                patient.Checkups.Add(checkup);
                db.Checkups.Add(checkup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(checkup);
        }

        // GET: Checkups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkup checkup = db.Checkups.Find(id);
            if (checkup == null)
            {
                return HttpNotFound();
            }
            return View(checkup);
        }

        // POST: Checkups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CheckupId,CheckupDate,CheckupType,Age,Height,Weight,BP,BMI,BodyFat,LossGain,Amount,TotalLoss,DailyWaterIntake,Cycle,Excercising,FollowingFoodGuidelines,HCG,Hips,Waist,Chest,Arm,ScriptToFill,StaffNotes,DoctorNotes,Signature,FillScript")] Checkup checkup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checkup);
        }

        // GET: Checkups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkup checkup = db.Checkups.Find(id);
            if (checkup == null)
            {
                return HttpNotFound();
            }
            return View(checkup);
        }

        // POST: Checkups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Checkup checkup = db.Checkups.Find(id);
            db.Checkups.Remove(checkup);
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
