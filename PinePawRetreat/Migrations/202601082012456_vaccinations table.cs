namespace PinePawRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vaccinationstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VaccinationModels",
                c => new
                    {
                        VaccID = c.Guid(nullable: false),
                        PetID = c.Guid(nullable: false),
                        VaccName = c.Int(nullable: false),
                        DatePerformed = c.DateTime(nullable: false),
                        DateDue = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VaccID)
                .ForeignKey("dbo.PetModels", t => t.PetID, cascadeDelete: true)
                .Index(t => t.PetID);
            
            AddColumn("dbo.PetModels", "Weight", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VaccinationModels", "PetID", "dbo.PetModels");
            DropIndex("dbo.VaccinationModels", new[] { "PetID" });
            DropColumn("dbo.PetModels", "Weight");
            DropTable("dbo.VaccinationModels");
        }
    }
}
