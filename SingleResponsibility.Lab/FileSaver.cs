using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility.Lab
{
    class FileLoger
    {
        public void Handle(string error)
        {
            File.WriteAllText(@"C:\Error.txt", error);
        }
    }
}
