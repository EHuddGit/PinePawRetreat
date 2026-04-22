namespace PinePawRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vaccinationverifiedStatusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VaccinationModels", "VaccinationStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VaccinationModels", "VaccinationStatus");
        }
    }
}
