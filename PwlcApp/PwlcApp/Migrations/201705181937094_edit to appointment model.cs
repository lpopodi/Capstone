namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittoappointmentmodel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Appointments");
            AddColumn("dbo.Appointments", "eventId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Appointments", "eventId");
            DropColumn("dbo.Appointments", "id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Appointments");
            DropColumn("dbo.Appointments", "eventId");
            AddPrimaryKey("dbo.Appointments", "id");
        }
    }
}
