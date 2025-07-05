using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    internal class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}
