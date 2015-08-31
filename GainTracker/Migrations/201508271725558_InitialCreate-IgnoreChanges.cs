namespace GainTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateIgnoreChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackedDataId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackedData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrackedData");
            DropTable("dbo.DataPoints");
        }
    }
}
