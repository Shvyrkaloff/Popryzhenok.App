namespace Popryzhenok.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agents", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agents", "ImagePath");
        }
    }
}
