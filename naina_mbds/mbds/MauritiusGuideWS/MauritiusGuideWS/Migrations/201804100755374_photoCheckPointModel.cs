namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photoCheckPointModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photo_CheckPoint", "Photo_Code", c => c.String());
            AddColumn("dbo.Photo_CheckPoint", "Photo_Extension", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photo_CheckPoint", "Photo_Extension");
            DropColumn("dbo.Photo_CheckPoint", "Photo_Code");
        }
    }
}
