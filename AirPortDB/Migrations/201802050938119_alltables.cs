namespace AirPortDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alltables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Planes", "TimeEnterd", c => c.DateTime());
            AlterColumn("dbo.Planes", "TimeExist", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Planes", "TimeExist", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Planes", "TimeEnterd", c => c.DateTime(nullable: false));
        }
    }
}
