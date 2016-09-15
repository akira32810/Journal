namespace Journal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredBody : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JournalDatas", "BodyData", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JournalDatas", "BodyData", c => c.String());
        }
    }
}
