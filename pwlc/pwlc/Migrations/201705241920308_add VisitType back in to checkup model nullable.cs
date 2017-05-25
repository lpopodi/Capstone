namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVisitTypebackintocheckupmodelnullable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkups", "VisitType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Checkups", "VisitType");
        }
    }
}
