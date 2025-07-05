using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    internal class ShippableProduct:Product,IShippable // products that need Shipping
    {
        public double Weight { get; private set; }

        public ShippableProduct(string name, double price, int quantity, double weight)
            : base(name, price, quantity)
        {
            Weight = weight;
        }

        public override bool RequiresShipping() => true;
        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
