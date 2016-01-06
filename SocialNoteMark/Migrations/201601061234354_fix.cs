namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        InterestID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        BulletionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InterestID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Interests");
        }
    }
}
