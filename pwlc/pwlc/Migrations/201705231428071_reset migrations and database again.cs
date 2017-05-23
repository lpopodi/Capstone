namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetmigrationsanddatabaseagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentTypes",
                c => new
                    {
                        AppointmentTypeID = c.Int(nullable: false, identity: true),
                        ApptType = c.Int(nullable: false),
                        ApptCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApptDuration = c.Int(nullable: false),
                        ApptColor = c.String(),
                        ApptBorderColor = c.String(),
                        ApptTextColor = c.String(),
                    })
                .PrimaryKey(t => t.AppointmentTypeID);
            
            CreateTable(
                "dbo.Checkups",
                c => new
                    {
                        CheckupId = c.Int(nullable: false, identity: true),
                        CheckupDate = c.DateTime(nullable: false),
                        Age = c.Int(),
                        Height = c.String(),
                        Weight = c.String(),
                        BP = c.String(),
                        BMI = c.Double(),
                        BodyFat = c.Double(),
                        LossGain = c.Int(),
                        Amount = c.Double(),
                        TotalLoss = c.Double(),
                        DailyWaterIntake = c.Double(),
                        Cycle = c.String(),
                        Excercising = c.Int(),
                        FollowingFoodGuidelines = c.Int(),
                        HCG = c.Int(),
                        Hips = c.Double(),
                        Waist = c.Double(),
                        Chest = c.Double(),
                        Arm = c.Double(),
                        ScriptToFill = c.Int(),
                        FillScript = c.Int(),
                        StaffNotes = c.String(),
                        DoctorNotes = c.String(),
                        Signature = c.Byte(),
                        Patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CheckupId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Patient_PatientId);
            
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
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventId = c.String(nullable: false, maxLength: 128),
                        title = c.String(),
                        description = c.String(),
                        start = c.String(),
                        end = c.String(),
                        color = c.String(),
                        borderColor = c.String(),
                        textColor = c.String(),
                        Patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.eventId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.Injections",
                c => new
                    {
                        InjectionId = c.Int(nullable: false, identity: true),
                        InjectionDate = c.DateTime(),
                        LotNumber = c.String(),
                        ExpDate = c.DateTime(),
                        InjectionLocation = c.Int(),
                        Patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InjectionId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        Patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InvoiceId)
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Invoices", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Injections", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Events", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Checkups", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Invoices", new[] { "Patient_PatientId" });
            DropIndex("dbo.Injections", new[] { "Patient_PatientId" });
            DropIndex("dbo.Events", new[] { "Patient_PatientId" });
            DropIndex("dbo.Checkups", new[] { "Patient_PatientId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Items");
            DropTable("dbo.Invoices");
            DropTable("dbo.Injections");
            DropTable("dbo.Events");
            DropTable("dbo.Patients");
            DropTable("dbo.Checkups");
            DropTable("dbo.AppointmentTypes");
        }
    }
}
