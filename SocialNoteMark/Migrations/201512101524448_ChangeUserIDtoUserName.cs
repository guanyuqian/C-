namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIDtoUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bulletins", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.FriendRelations", "FromName", c => c.Int(nullable: false));
            AddColumn("dbo.FriendRelations", "ToName", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.UserTagLogs", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Bulletins", "UserID");
            DropColumn("dbo.FriendRelations", "FromID");
            DropColumn("dbo.FriendRelations", "ToID");
            DropColumn("dbo.Notes", "UserID");
            DropColumn("dbo.UserTagLogs", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserTagLogs", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.FriendRelations", "ToID", c => c.Int(nullable: false));
            AddColumn("dbo.FriendRelations", "FromID", c => c.Int(nullable: false));
            AddColumn("dbo.Bulletins", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.UserTagLogs", "UserName");
            DropColumn("dbo.Notes", "UserName");
            DropColumn("dbo.FriendRelations", "ToName");
            DropColumn("dbo.FriendRelations", "FromName");
            DropColumn("dbo.Bulletins", "UserName");
        }
    }
}
