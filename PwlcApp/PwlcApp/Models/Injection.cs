﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PwlcApp.Models
{
    public class Injection
    {
        [Key]
        public string InjectionId { get; set; }
        public DateTime InjectionDate { get; set; }
        public string LotNumber { get; set; }
        public DateTime ExpDate { get; set; }
        public InjectionLocation? InjectionLocation { get; set; }
    }

    public enum InjectionLocation
    {
        Arm,
        RightGlute,
        LeftGlute
    }
}