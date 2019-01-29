namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPlace_CommentaireTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Place_Comment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PlaceID = c.Int(nullable: false),
                        Commentaire = c.String(),
                        Notation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PlaceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Place_Comment", "UserID", "dbo.Users");
            DropForeignKey("dbo.Place_Comment", "PlaceID", "dbo.Places");
            DropIndex("dbo.Place_Comment", new[] { "PlaceID" });
            DropIndex("dbo.Place_Comment", new[] { "UserID" });
            DropTable("dbo.Place_Comment");
        }
    }
}
