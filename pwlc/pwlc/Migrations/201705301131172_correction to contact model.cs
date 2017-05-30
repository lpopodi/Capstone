namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctiontocontactmodel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Contacts", new[] { "patient_PatientId" });
            CreateIndex("dbo.Contacts", "Patient_PatientId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", new[] { "Patient_PatientId" });
            CreateIndex("dbo.Contacts", "patient_PatientId");
        }
    }
}
