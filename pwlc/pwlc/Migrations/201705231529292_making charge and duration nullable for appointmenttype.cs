namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makingchargeanddurationnullableforappointmenttype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppointmentTypes", "ApptCharge", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.AppointmentTypes", "ApptDuration", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppointmentTypes", "ApptDuration", c => c.Int(nullable: false));
            AlterColumn("dbo.AppointmentTypes", "ApptCharge", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
