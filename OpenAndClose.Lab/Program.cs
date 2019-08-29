using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAndClose.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //problem
            Customer cust = new Customer();
            cust.CustType = 2;
            Console.WriteLine(cust.getDiscount(10000));
            Console.ReadLine();
            //solution
            SolutionCustomer scut = new SilverCustomer();
            Console.WriteLine("----------------------Silver Customer-------------------");
            Console.WriteLine( scut.getDiscount(10000));
            scut = new goldCustomer();
            Console.WriteLine("----------------------Gold Customer-------------------");
            Console.WriteLine(scut.getDiscount(10000));            
            SolutionCustomer Spcust = new SolutionCustomer();
            Console.WriteLine("----------------------New Customer-------------------");
            Console.WriteLine(Spcust.getDiscount(10000));            
            Console.ReadLine();
        }
    }
}
