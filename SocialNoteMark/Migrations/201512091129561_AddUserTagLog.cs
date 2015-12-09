namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTagLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTagLogs",
                c => new
                    {
                        UserTagLogID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserTagLogID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTagLogs");
        }
    }
}
