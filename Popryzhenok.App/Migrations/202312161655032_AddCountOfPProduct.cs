namespace Popryzhenok.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountOfPProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HistoryOfReleaseProducts", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HistoryOfReleaseProducts", "Count");
        }
    }
}
