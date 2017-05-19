namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedmeasurementandaddedtocheckup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkups", "HCG", c => c.Boolean(nullable: false));
            AddColumn("dbo.Checkups", "Hips", c => c.Double(nullable: false));
            AddColumn("dbo.Checkups", "Waist", c => c.Double(nullable: false));
            AddColumn("dbo.Checkups", "Chest", c => c.Double(nullable: false));
            AddColumn("dbo.Checkups", "Arm", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Checkups", "Arm");
            DropColumn("dbo.Checkups", "Chest");
            DropColumn("dbo.Checkups", "Waist");
            DropColumn("dbo.Checkups", "Hips");
            DropColumn("dbo.Checkups", "HCG");
        }
    }
}
