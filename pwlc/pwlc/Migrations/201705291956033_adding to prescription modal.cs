namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingtoprescriptionmodal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "ScriptRx", c => c.String());
            AddColumn("dbo.Prescriptions", "ScriptDirections", c => c.String());
            AddColumn("dbo.Prescriptions", "Patient_PatientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Prescriptions", "Patient_PatientId");
            AddForeignKey("dbo.Prescriptions", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.Prescriptions", new[] { "Patient_PatientId" });
            DropColumn("dbo.Prescriptions", "Patient_PatientId");
            DropColumn("dbo.Prescriptions", "ScriptDirections");
            DropColumn("dbo.Prescriptions", "ScriptRx");
        }
    }
}
