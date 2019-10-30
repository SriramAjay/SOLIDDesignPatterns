using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattren.Lab
{
    static class VehicalFactory
    {
        public static IVehicals GetObject(int _intVehical)
        {
            switch (_intVehical)
            {
                case 1: return new SPulsar();
                case 2: return new SAppache();
                case 3: return new SHeroHonda();
                default:return new SHeroHonda();
                
            }

        }
    }
}
