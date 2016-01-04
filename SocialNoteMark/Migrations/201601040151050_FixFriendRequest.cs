namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFriendRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        FriendRequestID = c.Int(nullable: false, identity: true),
                        FromName = c.String(nullable: false),
                        ToName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FriendRequestID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FriendRequests");
        }
    }
}
