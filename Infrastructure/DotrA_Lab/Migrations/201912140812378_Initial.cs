namespace DotrA_Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminAccount = c.String(nullable: false, maxLength: 20, unicode: false),
                        AdminPW = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 10),
                        Picture = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        SupplierID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        Picture = c.String(),
                        Description = c.String(maxLength: 200),
                        Quantity = c.Int(nullable: false),
                        SalesPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Short(nullable: false),
                        Discount = c.Single(),
                        SubTotal = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Order", t => t.OrderID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        ShipperID = c.Int(nullable: false),
                        RecipientName = c.String(nullable: false, maxLength: 50),
                        RecipientPhone = c.String(nullable: false, maxLength: 20, unicode: false),
                        RecipientAddress = c.String(nullable: false, maxLength: 50),
                        PaymentID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Members", t => t.MemberID)
                .ForeignKey("dbo.Payment", t => t.PaymentID)
                .ForeignKey("dbo.Shippers", t => t.ShipperID)
                .Index(t => t.MemberID)
                .Index(t => t.ShipperID)
                .Index(t => t.PaymentID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        MemberAccount = c.String(nullable: false, maxLength: 20, unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20, unicode: false),
                        HashCode = c.String(nullable: false, maxLength: 250, unicode: false),
                        EmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                        ResetPasswordCode = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        PaymentMethod = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.PaymentID);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        ShipperName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ShipperID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        CampanyPhone = c.String(maxLength: 50, unicode: false),
                        CompanyAddress = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Order", "ShipperID", "dbo.Shippers");
            DropForeignKey("dbo.Order", "PaymentID", "dbo.Payment");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "MemberID", "dbo.Members");
            DropIndex("dbo.Order", new[] { "PaymentID" });
            DropIndex("dbo.Order", new[] { "ShipperID" });
            DropIndex("dbo.Order", new[] { "MemberID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Shippers");
            DropTable("dbo.Payment");
            DropTable("dbo.Members");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Admin");
        }
    }
}
