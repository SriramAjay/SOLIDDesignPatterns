using RespositoryPattrenLabSwitch.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryPattrenLabSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi this is for test");
            var data= CrudDAL.GETDATA();
            foreach (var item in data)
            {
                Console.WriteLine(item.MFG_ID);
            }
            Console.ReadLine();
        }
    }
}
