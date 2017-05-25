namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedquantitytoitemmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ItemQuantity");
        }
    }
}
