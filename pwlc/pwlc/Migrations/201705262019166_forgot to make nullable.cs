namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forgottomakenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ItemTotal", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ItemTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
