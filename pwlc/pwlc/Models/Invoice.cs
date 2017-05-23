using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pwlc.Models
{
    public class Invoice
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        //[ForeignKey("AppointmentType")]
        //public int ApptCharge { get; set; }
        //public virtual AppointmentType AppointmentType { get; set; }
        public virtual Patient Patient { get; set; }
    }
}