using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PwlcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PwlcApp.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            //if (isPatientUser != true)
            //{
                ApplicationDbContext context = new ApplicationDbContext();
                var appointmentList = context.Appointments;
                return View(appointmentList.ToList());
            //}
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public Boolean isPatientUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Patient")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


    }
}