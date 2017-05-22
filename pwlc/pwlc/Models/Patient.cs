﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pwlc.Models
{
    public class Patient
    {
        public Patient()
        {
            Events = new List<Event>();
            Checkups = new List<Checkup>();
            Injections = new List<Injection>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Checkup> Checkups { get; set; }
        public virtual ICollection<Injection> Injections { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }

    public enum ContactMethod
    {
        Phone,
        Text,
        Email
    }
}