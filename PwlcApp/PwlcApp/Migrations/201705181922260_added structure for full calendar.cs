namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstructureforfullcalendar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppointmentType", c => c.Int());
            DropColumn("dbo.Appointments", "allday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "allday", c => c.String());
            DropColumn("dbo.Appointments", "AppointmentType");
        }
    }
}
