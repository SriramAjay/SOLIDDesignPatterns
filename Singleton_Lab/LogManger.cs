using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Lab
{
    public sealed class LogManger : ILog
    {
       private LogManger() { }
        public static ILog GetInstance { get { return instance.Value; } }        

        private static readonly Lazy<ILog> instance = new Lazy<ILog>(()=>new LogManger());

        public void WriteLog(string str)
        {
            Console.WriteLine(str);
        }
    }
}
