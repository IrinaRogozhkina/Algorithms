using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bedrock Shop!");
            Console.Write("Please provide your customer id: ");
            var customerID = Console.ReadLine();
            int convertedCustomerID;

            if(!int.TryParse(customerID, out convertedCustomerID))
            {
                Console.WriteLine("Sorry, invalid customer ID");
                return;
            }

            Console.Write("Enter price value to search for: ");
            var searchValue = Console.ReadLine();
            decimal searchPrice;
            if (!decimal.TryParse(searchValue, out searchPrice))
            {
                throw new ArgumentOutOfRangeException("Invalid search price");
            }

            foreach (var product in Shop.SearchProducts(searchPrice))
            {
                Console.WriteLine("Search results");   
                Console.WriteLine("{0}. {1} - {2} - {3:c}", product.ProductID,
                    product.Name,
                    product.Description,
                    product.Price);
            }

            foreach (var product in Shop.GetAllProducts())
            {
                Console.WriteLine("All products");
                Console.WriteLine("{0}. {1} - {2} - {3:c}", product.ProductID,
                    product.Name, 
                    product.Description, 
                    product.Price);
            }
            bool continueShopping = true;
            while (continueShopping)
            {

                Console.Write("Select a product number to add to shopping cart: ");
                var pdtNumber = Console.ReadLine();
                int convertedPdtNumber;

                if (!int.TryParse(pdtNumber, out convertedPdtNumber))
                {
                    throw new ArgumentOutOfRangeException("Invalid product number");
                }

                Console.Write("How many of the product do you want to buy? ");
                var quantity = Console.ReadLine();
                int convertedQuantity;

                if (!int.TryParse(quantity, out convertedQuantity))
                {
                    throw new ArgumentOutOfRangeException("Invalid quantity");
                }

                Shop.AddProductToCart(convertedPdtNumber, convertedCustomerID, convertedQuantity);
                Console.WriteLine("Product successfully added to the shopping cart");
                Console.WriteLine("1. Proceed to checkout");
                Console.WriteLine("2. Continue shopping");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        continueShopping = false;
                        break;
                    case "2":
                        continueShopping = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid choice");
                }
            }

            Console.WriteLine("Your shopping cart contains the following: ");
            foreach (var item in Shop.GetShoppingCartDetails(convertedCustomerID))
            {
                Console.WriteLine("Product - {0}, Quantity - {1}, Total price - {2:c}", item.Product.Name, item.Quantity, item.SubTotal);
            }
        }
    }
}
