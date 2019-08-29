using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility.Lab
{
    /* Here a EmployeeRepository class has more responsiblities. one is insertion(EMP- there is no wrong to handle crud opertations 
     *  regarding emp. Those are all one domain) another one is file write
    * but here problem is, EmployeeRepository class not responsible for file write. In future any change occure on file(related)
    * we need to modify this class. And whole class need to test again. 
    * ref links https://www.c-sharpcorner.com/article/solid-single-responsibility-principle-with-c-sharp/
    * https://code-maze.com/single-responsibility-principle/
    * Solution:- we need to seperate file functionality. If any change occure in future we need not touch this class once again
    * 
    * */

    public class Problem//EmployeeRepository
    {
        FileLoger _log = new FileLoger();
        public void Add(Employee PEmp)
        {
            try
            {
                Console.WriteLine(PEmp.Ename);
                Console.WriteLine(PEmp.Eno);
            }
            catch (Exception ex)
            {
                //solution
                _log.Handle(ex.ToString());
                //File.WriteAllText(@"C:\Error.txt", ex.ToString());
            }
        }
    }
}


