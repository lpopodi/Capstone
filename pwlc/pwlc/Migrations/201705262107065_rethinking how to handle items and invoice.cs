namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rethinkinghowtohandleitemsandinvoice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "ItemTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "ItemTotal", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
