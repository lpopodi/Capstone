namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationstoappointmentmodel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Appointments");
            AddColumn("dbo.Appointments", "id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Appointments", "title", c => c.String());
            AddColumn("dbo.Appointments", "description", c => c.String());
            AddColumn("dbo.Appointments", "start", c => c.String());
            AddColumn("dbo.Appointments", "end", c => c.String());
            AddColumn("dbo.Appointments", "allday", c => c.String());
            AddColumn("dbo.Appointments", "color", c => c.String());
            AddColumn("dbo.Appointments", "borderColor", c => c.String());
            AddColumn("dbo.Appointments", "textColor", c => c.String());
            AddPrimaryKey("dbo.Appointments", "id");
            DropColumn("dbo.Appointments", "AppointmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "AppointmentId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Appointments");
            DropColumn("dbo.Appointments", "textColor");
            DropColumn("dbo.Appointments", "borderColor");
            DropColumn("dbo.Appointments", "color");
            DropColumn("dbo.Appointments", "allday");
            DropColumn("dbo.Appointments", "end");
            DropColumn("dbo.Appointments", "start");
            DropColumn("dbo.Appointments", "description");
            DropColumn("dbo.Appointments", "title");
            DropColumn("dbo.Appointments", "id");
            AddPrimaryKey("dbo.Appointments", "AppointmentId");
        }
    }
}
