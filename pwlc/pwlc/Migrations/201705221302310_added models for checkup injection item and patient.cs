namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmodelsforcheckupinjectionitemandpatient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checkups",
                c => new
                    {
                        CheckupId = c.String(nullable: false, maxLength: 128),
                        CheckupDate = c.DateTime(nullable: false),
                        CheckupType = c.Int(),
                        Age = c.Int(nullable: false),
                        Height = c.String(),
                        Weight = c.String(),
                        BP = c.String(),
                        BMI = c.Double(nullable: false),
                        BodyFat = c.Double(nullable: false),
                        LossGain = c.Boolean(nullable: false),
                        Amount = c.Double(nullable: false),
                        TotalLoss = c.Double(nullable: false),
                        DailyWaterIntake = c.Double(nullable: false),
                        Cycle = c.String(),
                        Excercising = c.Boolean(nullable: false),
                        FollowingFoodGuidelines = c.Boolean(nullable: false),
                        HCG = c.Boolean(nullable: false),
                        Hips = c.Double(nullable: false),
                        Waist = c.Double(nullable: false),
                        Chest = c.Double(nullable: false),
                        Arm = c.Double(nullable: false),
                        ScriptToFill = c.Boolean(nullable: false),
                        StaffNotes = c.String(),
                        DoctorNotes = c.String(),
                        Signature = c.Binary(),
                        FillScript = c.Int(),
                        Patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CheckupId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.Injections",
                c => new
                    {
                        InjectionId = c.String(nullable: false, maxLength: 128),
                        InjectionDate = c.DateTime(nullable: false),
                        LotNumber = c.String(),
                        ExpDate = c.DateTime(nullable: false),
                        InjectionLocation = c.Int(),
                        Patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InjectionId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        ItemName = c.String(),
                        ItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.String(nullable: false, maxLength: 128),
                        Chart = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ContactMethod = c.Int(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            AddColumn("dbo.Events", "Patient_PatientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "Patient_PatientId");
            AddForeignKey("dbo.Events", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Injections", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Events", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Checkups", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.Injections", new[] { "Patient_PatientId" });
            DropIndex("dbo.Events", new[] { "Patient_PatientId" });
            DropIndex("dbo.Checkups", new[] { "Patient_PatientId" });
            DropColumn("dbo.Events", "Patient_PatientId");
            DropTable("dbo.Patients");
            DropTable("dbo.Items");
            DropTable("dbo.Injections");
            DropTable("dbo.Checkups");
        }
    }
}
