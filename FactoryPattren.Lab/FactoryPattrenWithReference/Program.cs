using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattrenWithReference
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi this is for animal class");
            Console.WriteLine("Please enter animal name");
            string animal = Console.ReadLine();
            var obj = FactoryWithReflection.GetObject(animal);
            obj.Getdetails();
            Console.ReadLine();
        }
    }
}
