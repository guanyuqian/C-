namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBulletin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bulletins",
                c => new
                    {
                        BulletionID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Flag = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BulletionID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bulletins");
        }
    }
}
