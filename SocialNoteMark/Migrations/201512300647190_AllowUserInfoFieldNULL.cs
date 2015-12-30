namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowUserInfoFieldNULL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserInfoID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        RealName = c.String(),
                        Sex = c.String(),
                        Age = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.UserInfoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfoes");
        }
    }
}
