using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    internal class ShippingService
    {
        private const double SHIPPING_RATE_PER_KG = 10;

        public double CalculateShippingFee(List<IShippable> items)
        {
            if (items == null || items.Count == 0)
                return 0;

            double totalWeight = items.Sum(item => item.GetWeight()) / 1000.0; 
            return totalWeight * SHIPPING_RATE_PER_KG;
        }

        public void ShipItems(List<IShippable> items)
        {
            Console.WriteLine("** Shipment notice **");

            
            var groupedItems = items.GroupBy(item => item.GetName());

            double totalWeight = 0;
            foreach (var group in groupedItems)
            {
                int quantity = group.Count();
                double weight = group.First().GetWeight() * quantity;
                totalWeight += weight;

                Console.WriteLine($"{quantity}x {group.Key,-15} {weight,6:F0}g");
            }

            Console.WriteLine($"Total package weight {totalWeight / 1000:F1}kg");
            Console.WriteLine();
        }
    }
}
