namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDateTimeforinvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "InvoiceDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "InvoiceDate");
        }
    }
}
