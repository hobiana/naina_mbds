namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckPoints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeaconUuid = c.String(),
                        BeaconOrder = c.Int(nullable: false),
                        MajorId = c.Int(nullable: false),
                        MinorId = c.Int(nullable: false),
                        BeaconName = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        PlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId);
            
            CreateTable(
                "dbo.Photo_CheckPoint",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Photo_Path = c.String(),
                        Description = c.String(),
                        CheckPointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CheckPoints", t => t.CheckPointId, cascadeDelete: true)
                .Index(t => t.CheckPointId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlaceName = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        IsIndoor = c.Boolean(nullable: false),
                        IsOutdoor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckPoints", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.Photo_CheckPoint", "CheckPointId", "dbo.CheckPoints");
            DropIndex("dbo.Photo_CheckPoint", new[] { "CheckPointId" });
            DropIndex("dbo.CheckPoints", new[] { "PlaceId" });
            DropTable("dbo.Places");
            DropTable("dbo.Photo_CheckPoint");
            DropTable("dbo.CheckPoints");
        }
    }
}
