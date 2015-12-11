namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowUserNameNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bulletins", "UserName", c => c.String());
            AlterColumn("dbo.Notes", "UserName", c => c.String());
            AlterColumn("dbo.UserTagLogs", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserTagLogs", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Notes", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Bulletins", "UserName", c => c.String(nullable: false));
        }
    }
}
