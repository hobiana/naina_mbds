namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo_places : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photo_Place",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Photo_Path = c.String(),
                        Description = c.String(),
                        PlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photo_Place", "PlaceId", "dbo.Places");
            DropIndex("dbo.Photo_Place", new[] { "PlaceId" });
            DropTable("dbo.Photo_Place");
        }
    }
}
