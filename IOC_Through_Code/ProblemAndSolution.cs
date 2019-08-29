using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_Through_Code
{
    /*
     * Problem:- must go through once DIP(Dependency Inversion Principle)
     * Solution:- To Achieve Dependency Injection we use IOC. This is user for creating dependices from outside. 
     * Sample :- Unity
     */
    class Employess
    {
        IEmpDtls _empDtls;
        public Employess(IEmpDtls EmpDtls)
        {
            _empDtls = EmpDtls;
        }
        public void GetData() {
            Console.WriteLine( _empDtls.GetDetails());
        }
    }
    interface IEmpDtls
    {
        string GetDetails();
    }
    class DBRepository : IEmpDtls
    {
        public string GetDetails() {
            return "This Employee of MHS and I am Jr";
        }
    }
    class MSRepository : IEmpDtls
    {
        public string GetDetails()
        {
            return "This MS-Employee of MHS and I am Jr";
        }
    }
}
