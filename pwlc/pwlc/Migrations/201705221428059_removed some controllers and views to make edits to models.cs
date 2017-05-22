namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedsomecontrollersandviewstomakeeditstomodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.String(nullable: false, maxLength: 128),
                        Patient_PatientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Patient_PatientId);
            
            AddColumn("dbo.Checkups", "Invoice_InvoiceId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Checkups", "Invoice_InvoiceId");
            AddForeignKey("dbo.Checkups", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkups", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.Invoices", new[] { "Patient_PatientId" });
            DropIndex("dbo.Checkups", new[] { "Invoice_InvoiceId" });
            DropColumn("dbo.Checkups", "Invoice_InvoiceId");
            DropTable("dbo.Invoices");
        }
    }
}
