using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pwlc.Models
{
    public class Injection
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int InjectionId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? InjectionDate { get; set; }
        public string LotNumber { get; set; }
        public DateTime? ExpDate { get; set; }
        [DataType(DataType.Date)]
        public InjectionLocation? InjectionLocation { get; set; }

        public virtual Patient Patient { get; set; }
    }

    public enum InjectionLocation
    {
        Arm,
        RightGlute,
        LeftGlute
    }
}