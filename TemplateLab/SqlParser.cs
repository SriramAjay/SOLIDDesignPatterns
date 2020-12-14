using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateLab
{
    class SqlParser : GeneralParaser
    {
        public override void Welcome()
        {
            Console.WriteLine("Welcome to sqlparser");
        }

        protected override void Load()
        {
            Console.WriteLine("Done loading data from Sql");
        }

        protected override void Parse()
        {
            Console.WriteLine("Sql Paraser");
        }
        //public override void TestPublic()
        //{
        //    base.TestPublic();
        //    Console.WriteLine("It is testing from SQL");
        //}
        protected override void Dump()
        {
            base.Dump();
            Console.WriteLine("It is dump from SQL");
        }
    }
}
