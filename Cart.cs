using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public void Add(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException("Product cannot be null");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0");

            if (product.AvailableQuantity < quantity)
                throw new InvalidOperationException($"Insufficient quantity for {product.Name}. Available: {product.AvailableQuantity}");

            if (product.IsExpired())
                throw new InvalidOperationException($"Product {product.Name} is expired");

            
            product.AvailableQuantity -= quantity;

           
            var existingItem = items.FirstOrDefault(i => i.Product == product);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem(product, quantity));
            }
        }

        public List<CartItem> GetItems() => items;

        public bool IsEmpty() => items.Count == 0;

        public double CalculateSubtotal()
        {
            return items.Sum(item => item.Product.Price * item.Quantity);
        }

        public List<IShippable> GetShippableItems()
        {
            var shippableItems = new List<IShippable>();
            foreach (var item in items)
            {
                if (item.Product is IShippable shippable)
                {
                    
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        shippableItems.Add(shippable);
                    }
                }
            }
            return shippableItems;
        }
    }
}
