using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    internal class PerishableProduct: Product //Product with expiry date
    {
        public DateTime ExpiryDate { get; private set; }

        public PerishableProduct(string name, double price, int quantity, DateTime expiryDate)
            : base(name, price, quantity)
        {
            this.ExpiryDate = expiryDate;
        }

        public override bool IsExpired() => DateTime.Now > ExpiryDate;
    }
}
