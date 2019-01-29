namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnActiveCheckpoint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckPoints", "Active", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckPoints", "Active");
        }
    }
}
