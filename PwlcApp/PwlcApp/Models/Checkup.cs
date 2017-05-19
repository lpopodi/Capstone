using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PwlcApp.Models
{
    public class Checkup
    {
        [Key]
        public string CheckupId { get; set; }
        public DateTime CheckupDate { get; set; }
        public CheckupType? CheckupType { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BP { get; set; }
        public double BMI { get; set; }
        public double BodyFat { get; set; }
        public bool LossGain { get; set; }
        public double Amount { get; set; }
        public double TotalLoss { get; set; }
        public double DailyWaterIntake { get; set; }
        public string Cycle { get; set; }
        public bool Excercising { get; set; }
        public bool FollowingFoodGuidelines { get; set; }
        public bool HCG { get; set; }
        public double Hips { get; set; }
        public double Waist { get; set; }
        public double Chest { get; set; }
        public double Arm { get; set; }
        public bool ScriptToFill { get; set; }
        public string StaffNotes { get; set; }
        public string DoctorNotes { get; set; }
        public byte[] Signature { get; set; }

        public FillScript? FillScript { get; set; }

        public virtual Invoice Invoice { get; set; }
    }

    public enum FillScript
    {
        Practitioner,
        Pharmacy
    }

    public enum CheckupType
    {
        New,
        Checkup,
        Restart
    }

}