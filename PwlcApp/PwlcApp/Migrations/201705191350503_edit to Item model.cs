namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittoItemmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "ItemQuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "ItemQuantity", c => c.Int(nullable: false));
        }
    }
}
