namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editstomultiplemodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.String(nullable: false, maxLength: 128),
                        quantity = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckupDate = c.DateTime(nullable: false),
                        AppointmentType = c.Int(),
                        AppointmentCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            AddColumn("dbo.Checkups", "CheckupType", c => c.Int());
            AddColumn("dbo.Checkups", "Invoice_InvoiceId", c => c.String(maxLength: 128));
            AddColumn("dbo.Checkups", "Patient_PatientId", c => c.String(maxLength: 128));
            AddColumn("dbo.Injections", "Patient_PatientId", c => c.String(maxLength: 128));
            AddColumn("dbo.Items", "ItemQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "Invoice_InvoiceId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Checkups", "Invoice_InvoiceId");
            CreateIndex("dbo.Checkups", "Patient_PatientId");
            CreateIndex("dbo.Items", "Invoice_InvoiceId");
            CreateIndex("dbo.Injections", "Patient_PatientId");
            AddForeignKey("dbo.Items", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
            AddForeignKey("dbo.Checkups", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
            AddForeignKey("dbo.Checkups", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Injections", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Injections", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Checkups", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Checkups", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Items", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Injections", new[] { "Patient_PatientId" });
            DropIndex("dbo.Items", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.Checkups", new[] { "Patient_PatientId" });
            DropIndex("dbo.Checkups", new[] { "Invoice_InvoiceId" });
            DropColumn("dbo.Items", "Invoice_InvoiceId");
            DropColumn("dbo.Items", "ItemQuantity");
            DropColumn("dbo.Injections", "Patient_PatientId");
            DropColumn("dbo.Checkups", "Patient_PatientId");
            DropColumn("dbo.Checkups", "Invoice_InvoiceId");
            DropColumn("dbo.Checkups", "CheckupType");
            DropTable("dbo.Invoices");
        }
    }
}
