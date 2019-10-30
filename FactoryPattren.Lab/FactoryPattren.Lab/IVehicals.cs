using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattren.Lab
{
    public interface IVehicals
    {
         int Original_Price { get; }
        double GetPrice(int _intmodel);
    }
}
