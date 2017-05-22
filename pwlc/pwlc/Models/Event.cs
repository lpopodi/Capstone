using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace pwlc.Models
{
    [DataContract(Name = "Event")]
    public class Event
    {
        [Key]
        [DataMember]
        public string eventId { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string start { get; set; }
        [DataMember]
        public string end { get; set; }
        [DataMember]
        public string color { get; set; }
        [DataMember]
        public string borderColor { get; set; }
        [DataMember]
        public string textColor { get; set; }
        [DataMember]
        public EventType? EventType { get; set; }
        //public virtual Patient Id { get; set; }

        public Event()
        {
        }

        public Event(string t, string d, string s, string e, string col = null, string bcol = null, string tcol = null)
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

    public enum EventType
    {
        New,
        Checkup,
        Restart,
        Office
    }

}