namespace TMDT_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Avatar = c.String(),
                        Points = c.Int(),
                        Status = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        DateTimeOrder = c.DateTime(nullable: false),
                        Status = c.Int(),
                        OrderPhoneNumber = c.Int(),
                        Address = c.String(),
                        Email = c.String(),
                        TypePayment = c.Int(nullable: false),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Accounts", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        QuantityBuy = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        View = c.Int(),
                        Image = c.String(),
                        BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrandID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        StarRating = c.Int(),
                        UserID = c.Int(),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.UserID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.UserID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        setRole = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Event = c.String(),
                        DiscountPercent = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CodeRnd = c.String(),
                        Status = c.String(),
                        Image = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.EventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Reviews", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Reviews", "UserID", "dbo.Accounts");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Brands", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Accounts");
            DropIndex("dbo.Reviews", new[] { "ProductID" });
            DropIndex("dbo.Reviews", new[] { "UserID" });
            DropIndex("dbo.Brands", new[] { "CompanyID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Accounts", new[] { "RoleID" });
            DropTable("dbo.Discounts");
            DropTable("dbo.Roles");
            DropTable("dbo.Reviews");
            DropTable("dbo.Companies");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Accounts");
        }
    }
}
