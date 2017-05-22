namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtoidentitymodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventId = c.String(nullable: false, maxLength: 128),
                        title = c.String(),
                        description = c.String(),
                        start = c.String(),
                        end = c.String(),
                        color = c.String(),
                        borderColor = c.String(),
                        textColor = c.String(),
                        EventType = c.Int(),
                    })
                .PrimaryKey(t => t.eventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
