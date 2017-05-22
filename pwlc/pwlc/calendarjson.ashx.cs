using pwlc;
using pwlc.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace pwlc
{
    /// <summary>
    /// Summary description for calendarjson
    /// </summary>
    public class calendarjson : IHttpHandler
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Event> _cal = new List<Event>();
        public void ProcessRequest(HttpContext context)
        {
            //Here is where you populate List _cal with your source events
            var List = db.Events.ToList();

            if (context.Request.QueryString["e1"] != "false")
            {
                for (int x = 1; x < 10; x++)
                {
                    int addDay = x % 2 == 0 ? x : x + 1;
                    DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, addDay);
                    DateTime endDate = x % 4 == 0 ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, addDay + 2) : new DateTime(DateTime.Now.Year, DateTime.Now.Month, addDay);
                    _cal.Add(new Event(String.Format("Event1 {0}", x), "This is just a test event for source 1. Nothing to see really.", startDate.ToString("yyyy-MM-dd HH:mm"), endDate.ToString("yyyy-MM-dd HH:mm"), "#9fc6e7", "#1587bd", "#000000"));
                }
            }


            //This is the important part!
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(List<Event>));
            s.WriteObject(stream, _cal);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            context.Response.ContentType = "application/json";
            context.Response.Write(sr.ReadToEnd());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}