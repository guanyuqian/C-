namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wahtever : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        AnswererName = c.String(nullable: false),
                        AnswerContent = c.String(nullable: false),
                        AnswerTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID);
            
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        FriendRequestID = c.Int(nullable: false, identity: true),
                        FromName = c.String(nullable: false),
                        ToName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FriendRequestID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        QuestionDescription = c.String(),
                        QuestionerName = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questions");
            DropTable("dbo.FriendRequests");
            DropTable("dbo.Answers");
        }
    }
}
