using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattren.Lab
{

    class Pulsar
    {
        public int OriginalPrice { get { return 95000; } }
        
        public double GetPrice(int _intmodel)
        {
            if (_intmodel < 2015) { return OriginalPrice * 0.5; }
            else { return OriginalPrice * 0.2; }
        }
         
    }
    class Appache
    {
        public int AppacheOriginalPrice { get { return 125000; } }
        public double GetPrice(int _intmodel)
        {
            if (_intmodel < 2015) { return AppacheOriginalPrice * 0.4; }
            else { return AppacheOriginalPrice * 0.25; }
        }

    }
    class HeroHonda
    {
        public int HHOriginalPrice { get { return 70000; } }
        public double GetPrice(int _intmodel)
        {
            if (_intmodel < 2015) { return HHOriginalPrice * 0.5; }
            else { return HHOriginalPrice * 0.3; }
        }

    }
}
