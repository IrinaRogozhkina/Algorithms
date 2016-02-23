namespace BedrockShop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopModel : DbContext
    {
        // Your context has been configured to use a 'ShopModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BedrockShop.ShopModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShopModel' 
        // connection string in the application configuration file.
        public ShopModel()
            : base("name=ShopModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Customer> Customers { get; set; }
         public virtual DbSet<Product> Products { get; set; }
         public virtual DbSet<OrderHeader> OrderHeaders { get; set; }
         public virtual DbSet<OrderDetail> OrderDetais { get; set; }
         public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
         public virtual DbSet<ShoppingCartDetail> ShoppingCartDetails { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}