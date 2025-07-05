using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class Product
    {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public int AvailableQuantity { get; set; }

        protected Product(string name, double price, int quantity)
        {
           this.Name = name;
           this.Price = price;
           this.AvailableQuantity = quantity;
        }  
        public virtual bool IsExpired() => false;
        public virtual bool RequiresShipping() => false;
    }
}
