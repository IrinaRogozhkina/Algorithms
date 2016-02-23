using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public static class Shop
    {
        public class SearchCriteria
        {
            public string CriteriaName { get; set; }
            public string Operator { get; set; }
            public string Value { get; set; }
        }

        #region Methods

        public static IEnumerable<Product> SearchProducts(decimal priceValue)
        {
            var db = new ShopModel();
            return db.Products.Where(p => p.Price <= priceValue);
        }

        public static Customer CreateCustomer(string name, int ssn, string address, string email)
        {
            using (var db = new ShopModel())
            {
                var c = new Customer();

                c.Name = name;
                c.SSN = ssn;
                c.Address = address;
                c.EmailAddress = email;

                db.Customers.Add(c);
                db.SaveChanges();
                return c;
            }
        }

        public static Product CreateProduct(string name, string description, 
            decimal price, decimal weight, string image)
        {
            using (var db = new ShopModel())
            {
                var p = new Product
                {
                    Name = name,
                    Description = description,
                    Weight = weight,
                    Price = price,
                    Image = image
                };
                db.Products.Add(p);
                db.SaveChanges();

                return p;
            }
        }

        public static IEnumerable<ShoppingCartDetail> GetShoppingCartDetails(int customerID)
        {
            var db = new ShopModel();
            var shoppingCart = db.ShoppingCarts.Where(s => s.CustomerID == customerID).FirstOrDefault();
            if(shoppingCart == null)
            {
                throw new ArgumentException("Shopping cart not found for the customer");
            }
            return db.ShoppingCartDetails.Where(d => d.ShoppingCartID == shoppingCart.ShoppingCartID);
        } 

        public static void AddProductToCart(int productID, int customerID, int quantity)
        {
            using (var db = new ShopModel())
            {
                //LINQ & Lambda
               var cart = 
                    db.ShoppingCarts.Where(s => s.CustomerID == customerID).FirstOrDefault();
                if (cart == null)
                {
                    // Did not find a cart
                    cart = new ShoppingCart
                    {
                        CustomerID = customerID
                    };
                    db.ShoppingCarts.Add(cart);
                }
                var product = db.Products.Where(p => p.ProductID == productID).FirstOrDefault();
                if (product != null)
                {
                    var detailEntry = new ShoppingCartDetail
                    {
                        ShoppingCartID = cart.ShoppingCartID,
                        ProductId = product.ProductID,
                        Quantity = quantity,
                        SubTotal = quantity * product.Price
                    };
                    db.ShoppingCartDetails.Add(detailEntry);
                }

                db.SaveChanges();
            }
        }

        public static IEnumerable<Product> GetAllProducts()
        {
            var db = new ShopModel();
            return db.Products;
        }

        #endregion
    }
}
