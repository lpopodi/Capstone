using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PwlcApp.Models
{
    public class Appointment
    {
        [Key]
        public string eventId { get; set; }

        public string title { get; set; }

        public string description { get; set; }
       
        public string start { get; set; }

        public string end { get; set; }

        public string color { get; set; }

        public string borderColor { get; set; }

        public string textColor { get; set; }
        public AppointmentType? AppointmentType { get; set; }
        public virtual Patient Id { get; set; }

        public Appointment()
        {
        }

        public Appointment(string t, string d, string s, string e, string col = null, string bcol = null, string tcol = null)
        {
            title = t;
            description = d;
            start = s;
            end = e;
            color = col;
            borderColor = bcol;
            textColor = tcol;
        }

    }

    public enum AppointmentType
    {
        New,
        Checkup,
        Restart
    }
}