namespace PinePawRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vaccinations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VaccinationModels", "Verified", c => c.Boolean(nullable: false));
            AddColumn("dbo.VaccinationModels", "VerifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VaccinationModels", "VerifiedBy");
            DropColumn("dbo.VaccinationModels", "Verified");
        }
    }
}
