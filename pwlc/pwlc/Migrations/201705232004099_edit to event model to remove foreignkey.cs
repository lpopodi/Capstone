namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittoeventmodeltoremoveforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "AppointmentTypeId", "dbo.AppointmentTypes");
            DropIndex("dbo.Events", new[] { "AppointmentTypeId" });
            RenameColumn(table: "dbo.Events", name: "AppointmentTypeId", newName: "AppointmentType_AppointmentTypeID");
            AlterColumn("dbo.Events", "AppointmentType_AppointmentTypeID", c => c.Int());
            CreateIndex("dbo.Events", "AppointmentType_AppointmentTypeID");
            AddForeignKey("dbo.Events", "AppointmentType_AppointmentTypeID", "dbo.AppointmentTypes", "AppointmentTypeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "AppointmentType_AppointmentTypeID", "dbo.AppointmentTypes");
            DropIndex("dbo.Events", new[] { "AppointmentType_AppointmentTypeID" });
            AlterColumn("dbo.Events", "AppointmentType_AppointmentTypeID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Events", name: "AppointmentType_AppointmentTypeID", newName: "AppointmentTypeId");
            CreateIndex("dbo.Events", "AppointmentTypeId");
            AddForeignKey("dbo.Events", "AppointmentTypeId", "dbo.AppointmentTypes", "AppointmentTypeID", cascadeDelete: true);
        }
    }
}
