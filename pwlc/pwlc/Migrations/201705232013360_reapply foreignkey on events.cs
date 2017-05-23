namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reapplyforeignkeyonevents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "AppointmentType_AppointmentTypeID", "dbo.AppointmentTypes");
            DropIndex("dbo.Events", new[] { "AppointmentType_AppointmentTypeID" });
            RenameColumn(table: "dbo.Events", name: "AppointmentType_AppointmentTypeID", newName: "AppointmentTypeId");
            AlterColumn("dbo.Events", "AppointmentTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "AppointmentTypeId");
            AddForeignKey("dbo.Events", "AppointmentTypeId", "dbo.AppointmentTypes", "AppointmentTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "AppointmentTypeId", "dbo.AppointmentTypes");
            DropIndex("dbo.Events", new[] { "AppointmentTypeId" });
            AlterColumn("dbo.Events", "AppointmentTypeId", c => c.Int());
            RenameColumn(table: "dbo.Events", name: "AppointmentTypeId", newName: "AppointmentType_AppointmentTypeID");
            CreateIndex("dbo.Events", "AppointmentType_AppointmentTypeID");
            AddForeignKey("dbo.Events", "AppointmentType_AppointmentTypeID", "dbo.AppointmentTypes", "AppointmentTypeID");
        }
    }
}
