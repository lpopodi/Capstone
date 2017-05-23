using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pwlc.Models
{
    public class AppointmentType
    {
        [Key]
        public int AppointmentTypeID { get; set; }
        public ApptType ApptType { get; set; }
        public decimal? ApptCharge { get; set; }
        public double ApptDuration { get; set; }
        public string ApptColor { get; set; }
        public string ApptBorderColor { get; set; }
        public string ApptTextColor { get; set; }
    }

    public enum ApptType
    {
        New,
        Checkup,
        Restart,
        Other
    }
}