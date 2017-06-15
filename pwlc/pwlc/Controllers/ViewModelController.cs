using pwlc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pwlc.Controllers
{
    public class ViewModelController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewModel
        public ActionResult Index(string id)
        {
            List<object> patientModel = new List<object>();
            patientModel.Add(db.Patients.Where(i => i.PatientId == id).First());
            patientModel.Add(db.Checkups.Where(c => c.Patient.PatientId == id).ToList());
            patientModel.Add(db.Injections.Where(c => c.Patient.PatientId == id).ToList());
            patientModel.Add(db.Prescriptions.Where(c => c.Patient.PatientId == id).ToList());
            patientModel.Add(db.Invoices.Where(c => c.Patient.PatientId == id).ToList());
            patientModel.Add(db.Events.Where(c => c.Patient.PatientId == id).ToList());
            patientModel.Add(db.Contacts.Where(c => c.Patient.PatientId == id).ToList());
            return View();
        }

        public ActionResult CustomerInfo(string id)
        {
            var thisCustomerInfo = db.Patients.Where(c => c.PatientId == id).ToList();
            return PartialView(thisCustomerInfo);
        }

        public ActionResult CustomerCheckups(string id)
        {
            var thisCustomerCheckups = db.Checkups.Where(c => c.Patient.PatientId == id).ToList();
            return PartialView(thisCustomerCheckups);
        }

        public ActionResult CustomerInjections(string id)
        {
            var thisCustomerInjections = db.Injections.Where(c => c.Patient.PatientId == id).ToList();
            return PartialView(thisCustomerInjections);
        }

        public ActionResult CustomerPrescriptions(string id)
        {
            var thisCustomerPrescriptions = db.Prescriptions.Where(c => c.Patient.PatientId == id).ToList();
            return PartialView(thisCustomerPrescriptions);
        }

        public ActionResult CustomerInvoices(string id)
        {
            var thisCustomerInvoices = db.Invoices.Where(c => c.Patient.PatientId == id).ToList();
            return PartialView(thisCustomerInvoices);
        }

        public ActionResult CustomerEvents(string id)
        {
            var thisCustomerEvents = db.Events.Where(c => c.Patient.PatientId == id).ToList();
            return PartialView(thisCustomerEvents);
        }

        public ActionResult CustomerContacts(string id)
        {
            var thisCustomerContacts = db.Contacts.Where(c => c.Patient.PatientId == id).ToList();
            return PartialView(thisCustomerContacts);
        }
    }
}