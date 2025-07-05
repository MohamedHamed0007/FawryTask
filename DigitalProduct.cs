using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    internal class DigitalProduct: Product //product that doesn't expire date or doesn't require shipping
    {
        public DigitalProduct(string name, double price, int quantity)
               : base(name, price, quantity)
        {
        }
    }
}
