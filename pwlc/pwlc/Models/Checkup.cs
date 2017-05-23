using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pwlc.Models
{
    public class Checkup
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CheckupId { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckupDate { get; set; }
        public int? Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BP { get; set; }
        public double? BMI { get; set; }
        public double? BodyFat { get; set; }
        public LossGain? LossGain { get; set; }
        public double? Amount { get; set; }
        public double? TotalLoss { get; set; }
        public double? DailyWaterIntake { get; set; }
        public string Cycle { get; set; }
        public Excercising? Excercising { get; set; }
        public FollowingFoodGuidelines? FollowingFoodGuidelines { get; set; }
        public HCG? HCG { get; set; }
        public double? Hips { get; set; }
        public double? Waist { get; set; }
        public double? Chest { get; set; }
        public double? Arm { get; set; }
        public ScriptToFill? ScriptToFill { get; set; }
        public FillScript? FillScript { get; set; }
        public string StaffNotes { get; set; }
        public string DoctorNotes { get; set; }
        public byte? Signature { get; set; }

        //[ForeignKey("AppointmentType")]
        //public ApptType AppType { get; set; }
        //public virtual AppointmentType AppointmentType { get; set; }
        public virtual Patient Patient { get; set; }

    }

    public enum FillScript
    {
        Practitioner,
        Pharmacy
    }

    public enum Excercising
    {
        Yes,
        No
    }

    public enum FollowingFoodGuidelines
    {
        Yes,
        No
    }

    public enum HCG
    {
        Yes,
        No
    }

    public enum ScriptToFill
    {
        Yes,
        No
    }

    public enum LossGain
    {
        Loss,
        Gain,
        None
    }

    public enum VisitType
    {
        New,
        Checkup,
        Restart,
        Other
    }
}