using DYMO.Label.Framework;
using Newtonsoft.Json;
using pwlc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pwlc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public string CalJSON()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return JsonConvert.SerializeObject(db.Events.ToList());
        }

        public ActionResult Search(string option, string search)
        {
            ApplicationDbContext db = new ApplicationDbContext();
              
            if (option == "Chart")
            {
                var searchResult = db.Patients.Where(s => s.Chart == search || search == null);
                return View(searchResult.ToList());
            }
            else if (option == "Last Name")
            {
                var searchResult = db.Patients.Where(s => s.LastName.StartsWith(search) || search == null);
                return View(searchResult.ToList());
            }
            else
            {
                var searchResult = db.Patients.Where(s => s.LastName == "blahblahblah");
                return View(searchResult.ToList());
            }
        }

        public ActionResult Report()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Patient> neglectList = new List<Patient>();
            int numDayCheck = 21;
            DateTime today = DateTime.Now;
            var patientCheckups = db.Patients.ToList();
            foreach (var patient in patientCheckups)
            {
                if (patient.Checkups.Count >= 1)
                {
                    var lastCheckup = patient.Checkups.Last();
                    var lastCheckupDate = lastCheckup.CheckupDate;
                    TimeSpan t = today - lastCheckupDate;
                    double NumOfDays = t.TotalDays;
                    if (NumOfDays > numDayCheck)
                    {
                        neglectList.Add(patient);
                    }
                }
            }
            ViewBag.Report = neglectList;
            return View();
        }

        public void Print(int? id)
        {
            //Prescription prescription = db.Prescriptions.Find(id);
            //Patient patient = db.Patients.Where(p => p.PatientId == prescription.Patient.PatientId).First();
            var today = DateTime.Today.ToString();
            var label = Label.Open(AppDomain.CurrentDomain.BaseDirectory + "Labels/PatientLabel.label");
            label.SetObjectText("lblName", "FirstName LastName");
            label.SetObjectText("lblToday", today);
            label.SetObjectText("lblAddress", "Address Line 1");
            label.SetObjectText("lblRxNum", "RX#");
            label.SetObjectText("lblAddres2", "Address Line 2");
            label.SetObjectText("lblDob", "Date of Birth");
            label.SetObjectText("lblPrescription", "Prescription");
            label.SetObjectText("lblDirections", "Directions");
            label.SetObjectText("lblRefill", "No Refills");
            label.Print("DYMO LabelWriter 450");
        }

    }
}