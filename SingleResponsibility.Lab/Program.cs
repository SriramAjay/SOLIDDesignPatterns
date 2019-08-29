using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee { Ename = "ajay", Eno = "1" };
            Problem p = new Problem();
            p.Add(emp);
            Console.ReadKey();
        }
    }
}
