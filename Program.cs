using System;
using System.Collections.Generic;
using System.Linq;

namespace FawryTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cheese = new ShippablePerishableProduct("Cheese", 100, 0, DateTime.Now.AddDays(20), 200);
            var biscuits = new ShippablePerishableProduct("Biscuits", 150, 5, DateTime.Now.AddDays(120), 700);
            var tv = new ShippableProduct("TV", 500, 3, 5000);
            var scratchCard = new DigitalProduct("Scratch Card", 50, 100);

            //create customer with balance 2000
            var customer = new Customer("Mohamed", 2000);

            //create cart and add items
            var cart = new Cart();

            try
            {
                cart.Add(cheese, 2);
                cart.Add(biscuits, 1);
                cart.Add(scratchCard, 1);


                var checkoutService = new CheckoutService();
                checkoutService.Checkout(customer, cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

      
    }

    

    
   
}
