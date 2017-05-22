using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual Patient Patient { get; set; }

    }
}