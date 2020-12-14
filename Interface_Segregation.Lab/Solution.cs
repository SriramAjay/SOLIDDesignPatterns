using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegrigation.Lab
{
   
        public interface ISPrinterTasks
        {
            void Print(string PrintContent);
            void Scan(string ScanContent);  
        }
        public interface IFax
        {
            void Fax(string FaxContent);
        }
        public interface IPrintDuplex
        {
            void PrintDuplex(string PrintDuplexContent);
        }

   
    public class HPSLaserJetPrinter : ISPrinterTasks,IFax,IPrintDuplex
    {
        public void Print(string PrintContent)
        {
            Console.WriteLine("Print Done");
        }
        public void Scan(string ScanContent)
        {
            Console.WriteLine("Scan content");
        }
        public void Fax(string FaxContent)
        {
            Console.WriteLine("Fax content");
        }
        public void PrintDuplex(string PrintDuplexContent)
        {
            Console.WriteLine("Print Duplex content");
        }
    }
}
