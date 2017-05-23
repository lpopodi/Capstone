namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingdurationfrominttodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppointmentTypes", "ApptDuration", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppointmentTypes", "ApptDuration", c => c.Int());
        }
    }
}
