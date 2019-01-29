namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLangueagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Languages");
        }
    }
}
