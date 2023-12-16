namespace Popryzhenok.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Address = c.String(),
                        Inn = c.String(),
                        Pkk = c.String(),
                        DirectorFullName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Priority = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Passport = c.String(),
                        BankNumber = c.String(),
                        IsFamily = c.Boolean(),
                        IsHealth = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Factories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoryOfReleaseProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentID = c.Int(),
                        ProductId = c.Int(),
                        DateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentID)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.AgentID)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Articul = c.String(),
                        Name = c.String(),
                        Type = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        MinPrice = c.Decimal(precision: 18, scale: 2),
                        WeightNetto = c.Double(),
                        WeightBrutto = c.Double(),
                        Sertificate = c.String(),
                        Standard = c.String(),
                        Count = c.Int(),
                        FactoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factories", t => t.FactoryId)
                .Index(t => t.FactoryId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        CountInBox = c.Int(),
                        Unit = c.String(),
                        CountInStorage = c.Int(),
                        MinCountInBox = c.Int(),
                        Description = c.String(),
                        Image = c.Binary(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MinCostChangeHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OldPrice = c.String(),
                        NewPrice = c.String(),
                        DateTime = c.DateTime(),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        DateOfComplete = c.DateTime(),
                        ManagerId = c.Int(),
                        Count = c.Int(),
                        IsPrePaid = c.Boolean(),
                        IsFullPaid = c.Boolean(),
                        IsDelivery = c.Boolean(),
                        IsChecked = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId)
                .ForeignKey("dbo.Employees", t => t.ManagerId)
                .Index(t => t.AgentId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaterialId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.RequestOnProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(),
                        ManagerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId)
                .ForeignKey("dbo.Employees", t => t.ManagerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.ManagerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Height = c.Int(),
                        Width = c.Int(),
                        Lenght = c.Int(),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(),
                        From = c.String(),
                        To = c.String(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Sizes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.RequestOnProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.RequestOnProducts", "ManagerId", "dbo.Employees");
            DropForeignKey("dbo.RequestOnProducts", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.Providers", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Offers", "ManagerId", "dbo.Employees");
            DropForeignKey("dbo.Offers", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.MinCostChangeHistories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.HistoryOfReleaseProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "FactoryId", "dbo.Factories");
            DropForeignKey("dbo.HistoryOfReleaseProducts", "AgentID", "dbo.Agents");
            DropIndex("dbo.Transfers", new[] { "EmployeeId" });
            DropIndex("dbo.Sizes", new[] { "ProductId" });
            DropIndex("dbo.RequestOnProducts", new[] { "ProductId" });
            DropIndex("dbo.RequestOnProducts", new[] { "ManagerId" });
            DropIndex("dbo.RequestOnProducts", new[] { "AgentId" });
            DropIndex("dbo.Providers", new[] { "MaterialId" });
            DropIndex("dbo.Offers", new[] { "ManagerId" });
            DropIndex("dbo.Offers", new[] { "AgentId" });
            DropIndex("dbo.MinCostChangeHistories", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "FactoryId" });
            DropIndex("dbo.HistoryOfReleaseProducts", new[] { "ProductId" });
            DropIndex("dbo.HistoryOfReleaseProducts", new[] { "AgentID" });
            DropTable("dbo.Transfers");
            DropTable("dbo.Sizes");
            DropTable("dbo.RequestOnProducts");
            DropTable("dbo.Providers");
            DropTable("dbo.Offers");
            DropTable("dbo.MinCostChangeHistories");
            DropTable("dbo.Materials");
            DropTable("dbo.Products");
            DropTable("dbo.HistoryOfReleaseProducts");
            DropTable("dbo.Factories");
            DropTable("dbo.Employees");
            DropTable("dbo.Agents");
        }
    }
}
