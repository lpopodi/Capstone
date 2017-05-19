namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodelforcheckup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checkups",
                c => new
                    {
                        CheckupId = c.String(nullable: false, maxLength: 128),
                        CheckupDate = c.DateTime(nullable: false),
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
                        StaffNotes = c.String(),
                        DoctorNotes = c.String(),
                        Signature = c.Binary(),
                        ScriptToFill = c.Boolean(nullable: false),
                        FillScript = c.Int(),
                    })
                .PrimaryKey(t => t.CheckupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Checkups");
        }
    }
}
