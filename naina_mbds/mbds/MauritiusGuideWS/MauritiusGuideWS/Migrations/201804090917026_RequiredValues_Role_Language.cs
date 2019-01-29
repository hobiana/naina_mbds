namespace MauritiusGuideWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredValues_Role_Language : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Languages", "Nom", c => c.String(nullable: false));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
            AlterColumn("dbo.Languages", "Nom", c => c.String());
        }
    }
}
