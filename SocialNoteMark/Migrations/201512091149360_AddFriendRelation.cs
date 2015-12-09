namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFriendRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRelations",
                c => new
                    {
                        FriendRelationID = c.Int(nullable: false, identity: true),
                        FromID = c.Int(nullable: false),
                        ToID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FriendRelationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FriendRelations");
        }
    }
}
