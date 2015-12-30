namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfos",
                c => new
                {
                    UserInfoID = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false),
                    RealName = c.String(nullable: false),
                    Sex = c.String(nullable: false),
                    Age = c.Int(nullable: false),
                    ImageUrl = c.String(nullable: false),
                })
                .PrimaryKey(t => t.UserInfoID);
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfos");
        }
    }
}
