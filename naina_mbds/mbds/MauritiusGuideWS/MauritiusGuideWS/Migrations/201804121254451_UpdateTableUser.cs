namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Pwd", c => c.String(nullable: false));
            AddColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "Pwd");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Name");
        }
    }
}
