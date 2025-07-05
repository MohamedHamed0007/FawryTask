using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    internal class ShippablePerishableProduct:PerishableProduct,IShippable //products that require shipping and has expiry date
    {
        public double Weight { get; private set; }

        public ShippablePerishableProduct(string name, double price, int quantity, DateTime expiryDate, double weight)
            : base(name, price, quantity, expiryDate)
        {
            Weight = weight;
        }

        public override bool RequiresShipping() => true;
        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
