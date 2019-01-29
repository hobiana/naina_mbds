namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debug : DbMigration
    {
        public override void Up()
        {
           /* DropForeignKey("dbo.Users", "Languages_ID", "dbo.Languages");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Users", new[] { "Languages_ID" });
            DropTable("dbo.Users");*/
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LangueID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Languages_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Users", "Languages_ID");
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Languages_ID", "dbo.Languages", "ID");
        }
    }
}
