namespace DotrA_Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                {
                    CategoryID = c.Int(nullable: false, identity: true),
                    CategoryName = c.String(nullable: false, maxLength: 50),
                    Categorydescript = c.String(),
                })
                .PrimaryKey(t => t.CategoryID);

            CreateTable(
                "dbo.ImageBase",
                c => new
                {
                    ImageID = c.Int(nullable: false, identity: true),
                    CatgoryID = c.Int(),
                    ProductID = c.Int(),
                    ImageName = c.String(nullable: false),
                    ImageUrl = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CatgoryID)
                .Index(t => t.CatgoryID)
                .Index(t => t.ProductID);

            CreateTable(
                "dbo.Product",
                c => new
                {
                    ProductID = c.Int(nullable: false, identity: true),
                    ProductName = c.String(nullable: false, maxLength: 50),
                    SupplierID = c.Int(nullable: false),
                    CategoryID = c.Int(nullable: false),
                    UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                    ProductDescription = c.String(),
                    Quantity = c.Int(nullable: false),
                    SalesPrice = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryID);

            CreateTable(
                "dbo.OrderDetail",
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
                .ForeignKey("dbo.Product", t => t.ProductID)
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
                .ForeignKey("dbo.Member", t => t.MemberID)
                .ForeignKey("dbo.Payment", t => t.PaymentID)
                .ForeignKey("dbo.Shipper", t => t.ShipperID)
                .Index(t => t.MemberID)
                .Index(t => t.ShipperID)
                .Index(t => t.PaymentID);

            CreateTable(
                "dbo.Member",
                c => new
                {
                    MemberID = c.Int(nullable: false, identity: true),
                    MemberAccount = c.String(nullable: false, maxLength: 20, unicode: false),
                    Password = c.String(nullable: false, unicode: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Email = c.String(nullable: false, maxLength: 50, unicode: false),
                    Address = c.String(nullable: false, maxLength: 50),
                    Phone = c.String(nullable: false, maxLength: 20, unicode: false),
                    RoleID = c.Int(nullable: false),
                    HashCode = c.String(nullable: false, maxLength: 250, unicode: false),
                    EmailVerified = c.Boolean(nullable: false),
                    ActivationCode = c.Guid(nullable: false),
                    ResetPasswordCode = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.MemberRole", t => t.RoleID)
                .Index(t => t.RoleID);

            CreateTable(
                "dbo.MemberRole",
                c => new
                {
                    RoleID = c.Int(nullable: false, identity: true),
                    RoleName = c.String(nullable: false, maxLength: 10, fixedLength: true),
                })
                .PrimaryKey(t => t.RoleID);

            CreateTable(
                "dbo.Payment",
                c => new
                {
                    PaymentID = c.Int(nullable: false, identity: true),
                    PaymentMethod = c.String(nullable: false, maxLength: 20, unicode: false),
                })
                .PrimaryKey(t => t.PaymentID);

            CreateTable(
                "dbo.Shipper",
                c => new
                {
                    ShipperID = c.Int(nullable: false, identity: true),
                    ShipperName = c.String(nullable: false, maxLength: 20),
                })
                .PrimaryKey(t => t.ShipperID);

            CreateTable(
                "dbo.Supplier",
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
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.ImageBase", "CatgoryID", "dbo.Category");
            DropForeignKey("dbo.Product", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Order", "ShipperID", "dbo.Shipper");
            DropForeignKey("dbo.Order", "PaymentID", "dbo.Payment");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "MemberID", "dbo.Member");
            DropForeignKey("dbo.Member", "RoleID", "dbo.MemberRole");
            DropForeignKey("dbo.ImageBase", "ProductID", "dbo.Product");
            DropIndex("dbo.Member", new[] { "RoleID" });
            DropIndex("dbo.Order", new[] { "PaymentID" });
            DropIndex("dbo.Order", new[] { "ShipperID" });
            DropIndex("dbo.Order", new[] { "MemberID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.Product", new[] { "SupplierID" });
            DropIndex("dbo.ImageBase", new[] { "ProductID" });
            DropIndex("dbo.ImageBase", new[] { "CatgoryID" });
            DropTable("dbo.Supplier");
            DropTable("dbo.Shipper");
            DropTable("dbo.Payment");
            DropTable("dbo.MemberRole");
            DropTable("dbo.Member");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Product");
            DropTable("dbo.ImageBase");
            DropTable("dbo.Category");
        }
    }
}
