namespace WebAppTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedbookingpetsandthejointableforthem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingModels",
                c => new
                    {
                        BookingID = c.Guid(nullable: false),
                        BookingStartTime = c.DateTime(nullable: false),
                        BookingEndTime = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        CheckedInTime = c.DateTime(nullable: false),
                        CheckedOutTime = c.DateTime(nullable: false),
                        CheckedInBy = c.String(),
                        CheckedOutBy = c.String(),
                        Owner_OwnerID = c.Guid(),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.OwnerModels", t => t.Owner_OwnerID)
                .Index(t => t.Owner_OwnerID);
            
            CreateTable(
                "dbo.PetModels",
                c => new
                    {
                        PetID = c.Guid(nullable: false),
                        PetName = c.String(nullable: false),
                        Breed = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Age = c.String(nullable: false),
                        Color = c.String(),
                        DietaryRequirements = c.String(),
                        MedicationRequirements = c.String(),
                        Owner_OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PetID)
                .ForeignKey("dbo.OwnerModels", t => t.Owner_OwnerID, cascadeDelete: true)
                .Index(t => t.Owner_OwnerID);
            
            CreateTable(
                "dbo.PetBookingModels",
                c => new
                    {
                        PetBookingID = c.Guid(nullable: false),
                        Booking_BookingID = c.Guid(nullable: false),
                        Pet_PetID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PetBookingID)
                .ForeignKey("dbo.BookingModels", t => t.Booking_BookingID, cascadeDelete: true)
                .ForeignKey("dbo.PetModels", t => t.Pet_PetID, cascadeDelete: true)
                .Index(t => t.Booking_BookingID)
                .Index(t => t.Pet_PetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetBookingModels", "Pet_PetID", "dbo.PetModels");
            DropForeignKey("dbo.PetBookingModels", "Booking_BookingID", "dbo.BookingModels");
            DropForeignKey("dbo.PetModels", "Owner_OwnerID", "dbo.OwnerModels");
            DropForeignKey("dbo.BookingModels", "Owner_OwnerID", "dbo.OwnerModels");
            DropIndex("dbo.PetBookingModels", new[] { "Pet_PetID" });
            DropIndex("dbo.PetBookingModels", new[] { "Booking_BookingID" });
            DropIndex("dbo.PetModels", new[] { "Owner_OwnerID" });
            DropIndex("dbo.BookingModels", new[] { "Owner_OwnerID" });
            DropTable("dbo.PetBookingModels");
            DropTable("dbo.PetModels");
            DropTable("dbo.BookingModels");
        }
    }
}
