namespace PinePawRetreat.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.5.1")]
    public sealed partial class Addedbookingpetsandthejointableforthem : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Addedbookingpetsandthejointableforthem));
        
        string IMigrationMetadata.Id
        {
            get { return "202511092230003_Added booking, pets, and the join table for them"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
