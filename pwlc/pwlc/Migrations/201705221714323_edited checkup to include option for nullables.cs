namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedcheckuptoincludeoptionfornullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Checkups", "Age", c => c.Int());
            AlterColumn("dbo.Checkups", "BMI", c => c.Double());
            AlterColumn("dbo.Checkups", "BodyFat", c => c.Double());
            AlterColumn("dbo.Checkups", "LossGain", c => c.Int());
            AlterColumn("dbo.Checkups", "Amount", c => c.Double());
            AlterColumn("dbo.Checkups", "TotalLoss", c => c.Double());
            AlterColumn("dbo.Checkups", "DailyWaterIntake", c => c.Double());
            AlterColumn("dbo.Checkups", "Excercising", c => c.Int());
            AlterColumn("dbo.Checkups", "FollowingFoodGuidelines", c => c.Int());
            AlterColumn("dbo.Checkups", "HCG", c => c.Int());
            AlterColumn("dbo.Checkups", "Hips", c => c.Double());
            AlterColumn("dbo.Checkups", "Waist", c => c.Double());
            AlterColumn("dbo.Checkups", "Chest", c => c.Double());
            AlterColumn("dbo.Checkups", "Arm", c => c.Double());
            AlterColumn("dbo.Checkups", "ScriptToFill", c => c.Int());
            AlterColumn("dbo.Checkups", "Signature", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Checkups", "Signature", c => c.Binary());
            AlterColumn("dbo.Checkups", "ScriptToFill", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Checkups", "Arm", c => c.Double(nullable: false));
            AlterColumn("dbo.Checkups", "Chest", c => c.Double(nullable: false));
            AlterColumn("dbo.Checkups", "Waist", c => c.Double(nullable: false));
            AlterColumn("dbo.Checkups", "Hips", c => c.Double(nullable: false));
            AlterColumn("dbo.Checkups", "HCG", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Checkups", "FollowingFoodGuidelines", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Checkups", "Excercising", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Checkups", "DailyWaterIntake", c => c.Double(nullable: false));
            AlterColumn("dbo.Checkups", "TotalLoss", c => c.Double(nullable: false));
            AlterColumn("dbo.Checkups", "Amount", c => c.Double(nullable: false));
            AlterColumn("dbo.Checkups", "LossGain", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Checkups", "BodyFat", c => c.Double(nullable: false));
            AlterColumn("dbo.Checkups", "BMI", c => c.Double(nullable: false));
            AlterColumn("dbo.Checkups", "Age", c => c.Int(nullable: false));
        }
    }
}
