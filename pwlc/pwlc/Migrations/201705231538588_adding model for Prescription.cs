namespace pwlc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodelforPrescription : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        ScriptId = c.Int(nullable: false, identity: true),
                        ScriptName = c.String(),
                    })
                .PrimaryKey(t => t.ScriptId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prescriptions");
        }
    }
}
