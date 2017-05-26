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
    }
}