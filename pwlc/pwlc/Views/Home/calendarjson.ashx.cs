using pwlc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;

namespace pwlc.Views.Home
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
            var List = db.Events.ToList();

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