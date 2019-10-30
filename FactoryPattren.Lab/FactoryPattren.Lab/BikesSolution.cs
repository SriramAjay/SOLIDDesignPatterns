using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattren.Lab
{
    
    class SPulsar:IVehicals
    {
        public int Original_Price { get { return 95000; } }

        public double GetPrice(int _intmodel)
        {
            if (_intmodel < 2015) { return Original_Price * 0.5; }
            else { return Original_Price * 0.2; }
        }

    }
    class SAppache:IVehicals
    {
        public int Original_Price { get { return 125000; } }
        public double GetPrice(int _intmodel)
        {
            if (_intmodel < 2015) { return Original_Price * 0.4; }
            else { return Original_Price * 0.25; }
        }

    }
    class SHeroHonda:IVehicals
    {
        public int Original_Price { get { return 70000; } }
        public double GetPrice(int _intmodel)
        {
            if (_intmodel < 2015) { return Original_Price * 0.5; }
            else { return Original_Price * 0.3; }
        }

    }
}
