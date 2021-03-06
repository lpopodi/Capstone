﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pwlc.Models
{
    public class Prescription
    {
        [Key]
        public int ScriptId { get; set; }
        public string ScriptName { get; set; }
        public string ScriptRx { get; set; }
        public string ScriptDirections { get; set; }

        public virtual Patient Patient { get; set; }
    }
}