using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public interface IShippable //this interface only for products that need shipping
    {
        string GetName();
        double GetWeight();
    }
}
