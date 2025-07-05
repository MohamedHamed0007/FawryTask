using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FawryTask.Program;

namespace FawryTask
{
    internal class CheckoutService
    {
        private ShippingService shippingService;

        public CheckoutService()
        {
            shippingService = new ShippingService();
        }

        public void Checkout(Customer customer, Cart cart)
        {
            
            if (cart.IsEmpty())
            {
                Console.WriteLine("Error: Cart is empty");
                return;
            }

            
            foreach (var item in cart.GetItems())
            {
                if (item.Product.IsExpired())
                {
                    Console.WriteLine($"Error: Product {item.Product.Name} is expired");
                    return;
                }
            }

            
            double subtotal = cart.CalculateSubtotal();
            var shippableItems = cart.GetShippableItems();
            double shippingFees = shippingService.CalculateShippingFee(shippableItems);
            double totalAmount = subtotal + shippingFees;

            
            if (customer.Balance < totalAmount)
            {
                Console.WriteLine($"Error: Insufficient balance. Required: {totalAmount:F2}, Available: {customer.Balance:F2}");
                return;
            }

            
            customer.Balance -= totalAmount;

            
            if (shippableItems.Count > 0)
            {
                shippingService.ShipItems(shippableItems);
            }

            
            PrintReceipt(cart, subtotal, shippingFees, totalAmount, customer.Balance);
        }

        private void PrintReceipt(Cart cart, double subtotal, double shippingFees, double totalAmount, double remainingBalance)
        {
            Console.WriteLine("** Checkout receipt **");

            foreach (var item in cart.GetItems())
            {
                double itemTotal = item.Product.Price * item.Quantity;
                Console.WriteLine($"{item.Quantity}x {item.Product.Name,-15} {itemTotal,6:F0}");
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal         {subtotal,6:F0}");
            Console.WriteLine($"Shipping         {shippingFees,6:F0}");
            Console.WriteLine($"Amount           {totalAmount,6:F0}");
            Console.WriteLine();
            Console.WriteLine($"Customer balance after payment: {remainingBalance:F2}");
        }
    }
}

