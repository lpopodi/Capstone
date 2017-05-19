using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PwlcApp.Models
{
    public class Invoice
    {
        [Key]
        public string InvoiceId { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public DateTime CheckupDate { get; set; }
        public AppointmentType? AppointmentType { get; set; }
        public decimal AppointmentCharge { get; set; }
        public ICollection<Item> Items { get; set; }

        public Invoice()
        {
            Items = new List<Item>();
        }

        
    }
}