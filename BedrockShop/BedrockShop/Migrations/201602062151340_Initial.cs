namespace BedrockShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartID = c.Int(nullable: false, identity: true),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            AddColumn("dbo.Products", "ShoppingCart_ShoppingCartID", c => c.Int());
            CreateIndex("dbo.Products", "ShoppingCart_ShoppingCartID");
            AddForeignKey("dbo.Products", "ShoppingCart_ShoppingCartID", "dbo.ShoppingCarts", "ShoppingCartID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ShoppingCart_ShoppingCartID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCarts", "CustomerID", "dbo.Customers");
            DropIndex("dbo.ShoppingCarts", new[] { "CustomerID" });
            DropIndex("dbo.Products", new[] { "ShoppingCart_ShoppingCartID" });
            DropColumn("dbo.Products", "ShoppingCart_ShoppingCartID");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
