namespace PinePawRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class explicitFKsandlazyloadingadded : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookingModels", name: "Owner_OwnerID", newName: "OwnerID");
            RenameColumn(table: "dbo.PetBookingModels", name: "Booking_BookingID", newName: "BookingID");
            RenameColumn(table: "dbo.PetModels", name: "Owner_OwnerID", newName: "OwnerID");
            RenameColumn(table: "dbo.PetBookingModels", name: "Pet_PetID", newName: "PetID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_Owner_OwnerID", newName: "IX_OwnerID");
            RenameIndex(table: "dbo.PetModels", name: "IX_Owner_OwnerID", newName: "IX_OwnerID");
            RenameIndex(table: "dbo.PetBookingModels", name: "IX_Pet_PetID", newName: "IX_PetID");
            RenameIndex(table: "dbo.PetBookingModels", name: "IX_Booking_BookingID", newName: "IX_BookingID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PetBookingModels", name: "IX_BookingID", newName: "IX_Booking_BookingID");
            RenameIndex(table: "dbo.PetBookingModels", name: "IX_PetID", newName: "IX_Pet_PetID");
            RenameIndex(table: "dbo.PetModels", name: "IX_OwnerID", newName: "IX_Owner_OwnerID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_OwnerID", newName: "IX_Owner_OwnerID");
            RenameColumn(table: "dbo.PetBookingModels", name: "PetID", newName: "Pet_PetID");
            RenameColumn(table: "dbo.PetModels", name: "OwnerID", newName: "Owner_OwnerID");
            RenameColumn(table: "dbo.PetBookingModels", name: "BookingID", newName: "Booking_BookingID");
            RenameColumn(table: "dbo.BookingModels", name: "OwnerID", newName: "Owner_OwnerID");
        }
    }
}
