namespace SocialNoteMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoteDescriptionChangeNameToTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Notes", "Description", c => c.String());
            DropColumn("dbo.Notes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Notes", "Description");
            DropColumn("dbo.Notes", "Title");
        }
    }
}
