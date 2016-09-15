namespace Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoDateEntries : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JournalDatas", "JournalDate", c => c.DateTime(defaultValueSql: "GETDATE()"));
            AlterColumn("dbo.JAttachments", "AttachedDate", c => c.DateTime(defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JournalDatas", "JournalDate");
            DropColumn("dbo.JAttachments", "AttachedDate");
        }
    }
}
