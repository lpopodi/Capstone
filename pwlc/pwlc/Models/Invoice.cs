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
        public Invoice()
        {
            Items = new List<Item>();
        }

        [Key]
        [HiddenInput(DisplayValue = false)]
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        
        public virtual Patient Patient { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}