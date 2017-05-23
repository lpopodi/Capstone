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
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(a => a.AppointmentType);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create(string pid)
        {
            if (pid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Patient patient = db.Patients.Find(pid);
            Event @event = new Event();
            @event.Patient = patient;
            @event.title = @event.Patient.FirstName + " " + @event.Patient.LastName;
            ViewBag.AppointmentTypeId = new SelectList(db.AppointmentTypes, "AppointmentTypeID", "ApptType");
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event @event, DateTime StartDate, DateTime StartTime, AppointmentType AppointmentType)
        {
            if (ModelState.IsValid)
            {
                @event.eventId = Guid.NewGuid().ToString();
                var chosenType = db.AppointmentTypes.Where(t => t.AppointmentTypeID == @event.AppointmentTypeId).First();
                var switchType = chosenType.ApptType.ToString();
                switch (switchType)
                {
                    case "New":
                        @event.description = "New Patient Appointment";
                        break;
                    case "Checkup":
                        @event.description = "Weekly Chekup Appointment";
                        break;
                    case "Restart":
                        @event.description = "Patient Restart Appointment";
                        break;
                    case "Other":
                        @event.description = "To Be Determined";
                        break;
                    default:
                        break;
                }
                @event.start = StartDate.ToString("yyyy-MM-dd ") + StartTime.ToString("HH:mm:ss");
                @event.color = chosenType.ApptColor;
                @event.borderColor = chosenType.ApptBorderColor;
                @event.textColor = chosenType.ApptTextColor;
                var minutesToAdd = chosenType.ApptDuration;
                var EndTime = StartTime + TimeSpan.FromMinutes(minutesToAdd);
                var EndDate = StartDate;
                @event.end = EndDate.ToString("yyyy-MM-dd ") + EndTime.ToString("HH:mm:ss");
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentTypeId = new SelectList(db.AppointmentTypes, "AppointmentTypeID", "ApptType", @event.AppointmentTypeId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentTypeId = new SelectList(db.AppointmentTypes, "AppointmentTypeID", "ApptColor", @event.AppointmentTypeId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventId,title,description,start,end,color,borderColor,textColor,AppointmentTypeId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentTypeId = new SelectList(db.AppointmentTypes, "AppointmentTypeID", "ApptColor", @event.AppointmentTypeId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
