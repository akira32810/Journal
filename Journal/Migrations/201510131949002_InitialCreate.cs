namespace Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JAttachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        FileName = c.String(),
                        AttachedDate = c.DateTime(nullable: false),
                        Journal_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.JournalDatas", t => t.Journal_ID)
                .Index(t => t.Journal_ID);
            
            CreateTable(
                "dbo.JournalDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        BodyData = c.String(),
                        JournalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JAttachments", "Journal_ID", "dbo.JournalDatas");
            DropIndex("dbo.JAttachments", new[] { "Journal_ID" });
            DropTable("dbo.JournalDatas");
            DropTable("dbo.JAttachments");
        }
    }
}
