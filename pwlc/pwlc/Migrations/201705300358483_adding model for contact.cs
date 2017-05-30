namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodelforcontact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactDescription = c.String(),
                        patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Patients", t => t.patient_PatientId)
                .Index(t => t.patient_PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "patient_PatientId", "dbo.Patients");
            DropIndex("dbo.Contacts", new[] { "patient_PatientId" });
            DropTable("dbo.Contacts");
        }
    }
}
