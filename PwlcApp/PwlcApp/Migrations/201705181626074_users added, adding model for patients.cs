namespace PwlcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersaddedaddingmodelforpatients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Chart = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ContactMethod = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
