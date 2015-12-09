namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoteTagLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoteTagLogs",
                c => new
                    {
                        NoteTagLogID = c.Int(nullable: false, identity: true),
                        NoteID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteTagLogID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NoteTagLogs");
        }
    }
}
