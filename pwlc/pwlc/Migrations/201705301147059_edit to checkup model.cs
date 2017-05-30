namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittocheckupmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Checkups", "Signature", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Checkups", "Signature", c => c.Byte());
        }
    }
}
