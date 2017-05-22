namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedstringkeytointkeyforcheckupandinvoice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checkups", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Checkups", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Events", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Injections", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Invoices", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.Checkups", new[] { "Invoice_InvoiceId" });
            DropPrimaryKey("dbo.Checkups");
            DropPrimaryKey("dbo.Invoices");
            DropPrimaryKey("dbo.Patients");
            AlterColumn("dbo.Checkups", "CheckupId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Checkups", "Invoice_InvoiceId", c => c.Int());
            AlterColumn("dbo.Invoices", "InvoiceId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Patients", "PatientId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Checkups", "CheckupId");
            AddPrimaryKey("dbo.Invoices", "InvoiceId");
            AddPrimaryKey("dbo.Patients", "PatientId");
            CreateIndex("dbo.Checkups", "Invoice_InvoiceId");
            AddForeignKey("dbo.Checkups", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
            AddForeignKey("dbo.Checkups", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Events", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Injections", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Invoices", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Injections", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Events", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Checkups", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Checkups", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Checkups", new[] { "Invoice_InvoiceId" });
            DropPrimaryKey("dbo.Patients");
            DropPrimaryKey("dbo.Invoices");
            DropPrimaryKey("dbo.Checkups");
            AlterColumn("dbo.Patients", "PatientId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Invoices", "InvoiceId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Checkups", "Invoice_InvoiceId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Checkups", "CheckupId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Patients", "PatientId");
            AddPrimaryKey("dbo.Invoices", "InvoiceId");
            AddPrimaryKey("dbo.Checkups", "CheckupId");
            CreateIndex("dbo.Checkups", "Invoice_InvoiceId");
            AddForeignKey("dbo.Invoices", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Injections", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Events", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Checkups", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Checkups", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
        }
    }
}
