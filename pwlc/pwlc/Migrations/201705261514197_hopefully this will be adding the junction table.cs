namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hopefullythiswillbeaddingthejunctiontable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Items", new[] { "Invoice_InvoiceId" });
            CreateTable(
                "dbo.ItemInvoices",
                c => new
                    {
                        Item_ItemId = c.String(nullable: false, maxLength: 128),
                        Invoice_InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_ItemId, t.Invoice_InvoiceId })
                .ForeignKey("dbo.Items", t => t.Item_ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId, cascadeDelete: true)
                .Index(t => t.Item_ItemId)
                .Index(t => t.Invoice_InvoiceId);
            
            DropColumn("dbo.Items", "Invoice_InvoiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Invoice_InvoiceId", c => c.Int());
            DropForeignKey("dbo.ItemInvoices", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.ItemInvoices", "Item_ItemId", "dbo.Items");
            DropIndex("dbo.ItemInvoices", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.ItemInvoices", new[] { "Item_ItemId" });
            DropTable("dbo.ItemInvoices");
            CreateIndex("dbo.Items", "Invoice_InvoiceId");
            AddForeignKey("dbo.Items", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
        }
    }
}
