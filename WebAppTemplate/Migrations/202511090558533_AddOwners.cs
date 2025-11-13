namespace WebAppTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwners : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OwnerModels",
                c => new
                    {
                        OwnerID = c.Guid(nullable: false),
                        OwnerName = c.String(nullable: false),
                        OwnerPhoneNumber = c.String(nullable: false),
                        OwnerEmail = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.OwnerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OwnerModels");
        }
    }
}
