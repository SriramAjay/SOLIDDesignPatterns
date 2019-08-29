using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion.Lab
{
   
  /*Consern:- If we inject from main method in future if we need to change DBstorageAgent to something else
 * we need to modify. Even that also we need to bulid the class and coupled here.
 * Here we need to introduce one concept like IOC[unity,autofac,ninject,windoser.. etc..]. It does dependies creation, detroying and passing.
 * It is third party , if any thing change occure we can bulid this class. This does not effect the modules.. 
 */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Dependency Inversion");
          
            //create dependency instance
            IStorageAgent datastoragepersistence = new DatabaseStorageAgentSolution();
            //inject dependency through constructor injection
            var Employee = new EmployeeSolution(datastoragepersistence);
            Employee.EmployeeName = "ajay";
            Employee.Salary = 10000;
            Employee.SaveEmployeeDetails();
            //Nullify the dependency instance
            datastoragepersistence = null;
            Console.WriteLine("Dependency Injection accomplished with main method acting as DI container");
            Console.ReadLine();
        }
    }
}
