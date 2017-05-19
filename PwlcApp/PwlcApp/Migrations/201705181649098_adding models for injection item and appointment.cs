namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmodelsforinjectionitemandappointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.String(nullable: false, maxLength: 128),
                        Id_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Patients", t => t.Id_Id)
                .Index(t => t.Id_Id);
            
            CreateTable(
                "dbo.Injections",
                c => new
                    {
                        InjectionId = c.String(nullable: false, maxLength: 128),
                        InjectionDate = c.DateTime(nullable: false),
                        LotNumber = c.String(),
                        ExpDate = c.DateTime(nullable: false),
                        InjectionLocation = c.Int(),
                    })
                .PrimaryKey(t => t.InjectionId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        ItemName = c.String(),
                        ItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Id_Id", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "Id_Id" });
            DropTable("dbo.Items");
            DropTable("dbo.Injections");
            DropTable("dbo.Appointments");
        }
    }
}
