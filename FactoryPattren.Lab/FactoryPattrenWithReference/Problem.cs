using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattrenWithReference
{
    public interface IAnimalInfo
    {
        void Getdetails();
    }

    class Tiger:IAnimalInfo
    {
        public void Getdetails() { Console.WriteLine("Speed is 50"); }
    }
    class Cheeta : IAnimalInfo {
        public void Getdetails() { Console.WriteLine("Speed is 120 "); }
    }
}
