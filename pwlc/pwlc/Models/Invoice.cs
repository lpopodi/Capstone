using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pwlc.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}