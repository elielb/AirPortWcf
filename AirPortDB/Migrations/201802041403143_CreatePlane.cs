namespace AirPortDB.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreatePlane : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planes",
                c => new
                {
                    PlaneID = c.Int(nullable: false, identity: true),
                    StatusFly = c.Int(nullable: false),
                    TimeEnterd = c.DateTime(nullable: false),
                    TimeExist = c.DateTime(nullable: false),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.PlaneID);
        }

        public override void Down()
        {
            DropTable("dbo.Planes");
        }
    }
}