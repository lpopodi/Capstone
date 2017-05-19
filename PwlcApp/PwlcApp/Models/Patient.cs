using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PwlcApp.Models
{
    public class Patient
    {
        public Patient()
        {
            Appointments = new List<Appointment>();
            Checkups = new List<Checkup>();
            Injections = new List<Injection>();
        }

        [Key]
        public string PatientId { get; set; }
        public string Chart { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ContactMethod? ContactMethod { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Checkup> Checkups { get; set; }
        public virtual ICollection<Injection> Injections { get; set; }
        //public virtual ICollection<Invoice> Invoice { get; set; }
    }

    public enum ContactMethod
    {
        Phone,
        Text,
        Email
    }
}