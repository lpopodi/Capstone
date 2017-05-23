namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workingonlookuptableandforeignkeyforappointmentTypeandEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "AppointmentTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "AppointmentTypeId");
            AddForeignKey("dbo.Events", "AppointmentTypeId", "dbo.AppointmentTypes", "AppointmentTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "AppointmentTypeId", "dbo.AppointmentTypes");
            DropIndex("dbo.Events", new[] { "AppointmentTypeId" });
            DropColumn("dbo.Events", "AppointmentTypeId");
        }
    }
}
