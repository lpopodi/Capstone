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
    public class AppointmentTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppointmentTypes
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Index()
        {
            return View(db.AppointmentTypes.ToList());
        }

        // GET: AppointmentTypes/Details/5
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentType appointmentType = db.AppointmentTypes.Find(id);
            if (appointmentType == null)
            {
                return HttpNotFound();
            }
            return View(appointmentType);
        }

        // GET: AppointmentTypes/Create
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentTypeID,ApptType,ApptCharge,ApptDuration,ApptColor,ApptBorderColor,ApptTextColor")] AppointmentType appointmentType)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentTypes.Add(appointmentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointmentType);
        }

        // GET: AppointmentTypes/Edit/5
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentType appointmentType = db.AppointmentTypes.Find(id);
            if (appointmentType == null)
            {
                return HttpNotFound();
            }
            return View(appointmentType);
        }

        // POST: AppointmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentTypeID,ApptType,ApptCharge,ApptDuration,ApptColor,ApptBorderColor,ApptTextColor")] AppointmentType appointmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointmentType);
        }

        // GET: AppointmentTypes/Delete/5
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentType appointmentType = db.AppointmentTypes.Find(id);
            if (appointmentType == null)
            {
                return HttpNotFound();
            }
            return View(appointmentType);
        }

        // POST: AppointmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentType appointmentType = db.AppointmentTypes.Find(id);
            db.AppointmentTypes.Remove(appointmentType);
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
