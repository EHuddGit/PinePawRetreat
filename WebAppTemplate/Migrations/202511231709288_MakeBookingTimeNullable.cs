namespace WebAppTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBookingTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingModels", "CheckedInTime", c => c.DateTime());
            AlterColumn("dbo.BookingModels", "CheckedOutTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingModels", "CheckedOutTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookingModels", "CheckedInTime", c => c.DateTime(nullable: false));
        }
    }
}
