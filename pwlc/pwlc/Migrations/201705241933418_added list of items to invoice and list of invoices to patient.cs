namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlistofitemstoinvoiceandlistofinvoicestopatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Invoice_InvoiceId", c => c.Int());
            CreateIndex("dbo.Items", "Invoice_InvoiceId");
            AddForeignKey("dbo.Items", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Items", new[] { "Invoice_InvoiceId" });
            DropColumn("dbo.Items", "Invoice_InvoiceId");
        }
    }
}
