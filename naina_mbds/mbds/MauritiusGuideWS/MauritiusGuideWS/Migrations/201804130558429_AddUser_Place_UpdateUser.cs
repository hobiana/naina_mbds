namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser_Place_UpdateUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_Place",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PlaceId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "Active", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Place", "UserId", "dbo.Users");
            DropForeignKey("dbo.User_Place", "PlaceId", "dbo.Places");
            DropIndex("dbo.User_Place", new[] { "UserId" });
            DropIndex("dbo.User_Place", new[] { "PlaceId" });
            DropColumn("dbo.Users", "State");
            DropTable("dbo.User_Place");
        }
    }
}
