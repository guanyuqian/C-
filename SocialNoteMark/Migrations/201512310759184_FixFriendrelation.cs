namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFriendrelation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FriendRelations", "FromName", c => c.String());
            AlterColumn("dbo.FriendRelations", "ToName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FriendRelations", "ToName", c => c.Int(nullable: false));
            AlterColumn("dbo.FriendRelations", "FromName", c => c.Int(nullable: false));
        }
    }
}
