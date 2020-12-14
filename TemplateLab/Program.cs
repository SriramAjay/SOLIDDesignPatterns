using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateLab
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralParaser gen = new SqlParser();
            gen.Process();
            //gen.TestPublic();
            gen.Wish("from main method");
            Console.ReadLine();

        }
    }
}
