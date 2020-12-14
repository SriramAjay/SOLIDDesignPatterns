using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//this is single ton no one able create object to logmanager. every one must access. because it has private constructor. not support inheritance because it has "sealed".
// it is only readonly. and it has with get property
namespace Singleton_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ILog log= LogManger.GetInstance;
            log.WriteLog(Console.ReadLine());
            Console.ReadLine();
        }
    }
}
