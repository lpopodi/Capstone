namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittopatientmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Id_Id", "dbo.Patients");
            RenameColumn(table: "dbo.Appointments", name: "Id_Id", newName: "Id_PatientId");
            RenameIndex(table: "dbo.Appointments", name: "IX_Id_Id", newName: "IX_Id_PatientId");
            DropPrimaryKey("dbo.Patients");
            AddColumn("dbo.Patients", "PatientId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Patients", "PatientId");
            AddForeignKey("dbo.Appointments", "Id_PatientId", "dbo.Patients", "PatientId");
            DropColumn("dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Appointments", "Id_PatientId", "dbo.Patients");
            DropPrimaryKey("dbo.Patients");
            DropColumn("dbo.Patients", "PatientId");
            AddPrimaryKey("dbo.Patients", "Id");
            RenameIndex(table: "dbo.Appointments", name: "IX_Id_PatientId", newName: "IX_Id_Id");
            RenameColumn(table: "dbo.Appointments", name: "Id_PatientId", newName: "Id_Id");
            AddForeignKey("dbo.Appointments", "Id_Id", "dbo.Patients", "Id");
        }
    }
}
