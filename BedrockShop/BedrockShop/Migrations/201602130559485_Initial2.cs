namespace BedrockShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartDetails",
                c => new
                    {
                        ShoppingCartDetailID = c.Int(nullable: false, identity: true),
                        ShoppingCartID = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ShoppingCartDetailID)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartID, cascadeDelete: true)
                .Index(t => t.ShoppingCartID)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartDetails", "ShoppingCartID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCartDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.ShoppingCartDetails", new[] { "ProductId" });
            DropIndex("dbo.ShoppingCartDetails", new[] { "ShoppingCartID" });
            DropTable("dbo.ShoppingCartDetails");
        }
    }
}
