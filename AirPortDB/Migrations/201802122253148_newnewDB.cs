namespace AirPortDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnewDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StationModelStationModels",
                c => new
                    {
                        StationModel_StationId = c.Int(nullable: false),
                        StationModel_StationId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StationModel_StationId, t.StationModel_StationId1 })
                .ForeignKey("dbo.StationModels", t => t.StationModel_StationId)
                .ForeignKey("dbo.StationModels", t => t.StationModel_StationId1)
                .Index(t => t.StationModel_StationId)
                .Index(t => t.StationModel_StationId1);
            
            DropColumn("dbo.StationModels", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StationModels", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.StationModelStationModels", "StationModel_StationId1", "dbo.StationModels");
            DropForeignKey("dbo.StationModelStationModels", "StationModel_StationId", "dbo.StationModels");
            DropIndex("dbo.StationModelStationModels", new[] { "StationModel_StationId1" });
            DropIndex("dbo.StationModelStationModels", new[] { "StationModel_StationId" });
            DropTable("dbo.StationModelStationModels");
        }
    }
}
