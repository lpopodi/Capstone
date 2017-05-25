﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PwlcApp.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log { get; set; }

        ILog log = log4net.LogManager.GetLogger(typeof(HomeController)); //type of class


        public ActionResult Index()
        {
            log.Debug("Debug Message");
            log.Warn("Warn Message");
            log.Fatal("Fatal Message");
            log.Error("Error Message");

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
    }
}