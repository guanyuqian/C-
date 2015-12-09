namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PermissionType = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreatTime = c.DateTime(nullable: false),
                        EditTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NoteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
        }
    }
}
