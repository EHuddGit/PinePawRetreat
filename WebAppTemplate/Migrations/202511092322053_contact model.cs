namespace WebAppTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class contactmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingModels", "Owner_OwnerID", "dbo.OwnerModels");
            DropIndex("dbo.BookingModels", new[] { "Owner_OwnerID" });

            CreateTable(
                "dbo.ContactModels",
                c => new
                {
                    ContactID = c.Guid(nullable: false),
                    NameFirst = c.String(nullable: false),
                    NameLast = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    PhoneNumber = c.String(),
                    Subject = c.String(nullable: false),
                    Message = c.String(nullable: false),
                    SubmittedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ContactID);

            AddColumn("dbo.PetModels", "Sex", c => c.String(nullable: false, maxLength: 1));

            AlterColumn("dbo.BookingModels", "Owner_OwnerID", c => c.Guid(nullable: false));
            CreateIndex("dbo.BookingModels", "Owner_OwnerID");

            AddForeignKey(
                "dbo.BookingModels",
                "Owner_OwnerID",
                "dbo.OwnerModels",
                "OwnerID",
                cascadeDelete: false
            );

            DropColumn("dbo.PetModels", "Gender");
        }

        public override void Down()
        {
            AddColumn("dbo.PetModels", "Gender", c => c.String(nullable: false, maxLength: 1));

            DropForeignKey("dbo.BookingModels", "Owner_OwnerID", "dbo.OwnerModels");
            DropIndex("dbo.BookingModels", new[] { "Owner_OwnerID" });
            AlterColumn("dbo.BookingModels", "Owner_OwnerID", c => c.Guid()); 
            DropColumn("dbo.PetModels", "Sex");
            DropTable("dbo.ContactModels");
            CreateIndex("dbo.BookingModels", "Owner_OwnerID");
            AddForeignKey(
                "dbo.BookingModels",
                "Owner_OwnerID",
                "dbo.OwnerModels",
                "OwnerID",
                cascadeDelete: true
            );
        }
    }
}
