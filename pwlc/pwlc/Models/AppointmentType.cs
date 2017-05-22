using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pwlc.Models
{
    public class AppointmentType
    {
        [Key]
        public int AppointmentTypeID { get; set; }
        public ApptType ApptType { get; set; }
        public decimal ApptCharge { get; set; }
        public int ApptDuration { get; set; }
    }

    public enum ApptType
    {
        New,
        Checkup,
        Restart,
        Other
    }
}