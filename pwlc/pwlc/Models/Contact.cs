using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pwlc.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public DateTime ContactDate { get; set; }
        public string ContactDescription { get; set; }

        public virtual Patient Patient { get; set; }
    }
}