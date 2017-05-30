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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public string CalJSON()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return JsonConvert.SerializeObject(db.Events.ToList());
        }

        public void Print(int? id)
        {
            //Prescription prescription = db.Prescriptions.Find(id);
            //Patient patient = db.Patients.Where(p => p.PatientId == prescription.Patient.PatientId).First();
            var today = DateTime.Today.ToString();
            var path = Server.MapPath("~/Labels/PatientLabel.label");
            var label = Label.Open(path);
            //var label = Label.Open(AppDomain.CurrentDomain.BaseDirectory + "Labels/PatientLabel.label");
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