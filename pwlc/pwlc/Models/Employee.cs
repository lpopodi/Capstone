using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pwlc.Models
{
    public class Employee
    {

        public Employee()
        {
            this.ReturnDate = DateTime.Now;
        }

        public DateTime ReturnDate { get; set; }

    }
}