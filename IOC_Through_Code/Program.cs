using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Basically if we observe below we are creating object and we are injecting.
 * Now we will do by IOC
 * Basically IOC prinicple say:- which seperated other things(other classes object creation, depend/subclass instantation etc..) from 
 * main functionality(to his main work like emp data only).
 * Benfits:-
 * Automatic Dependency Resolution When dependendencies are managed by the container there are less chances of error.
 * Suppose if our application has a lot of dependencies then injecting those dependencies is also difficult to manage 
 * if we are injecting them without a DI container.Decouples the client from the dependency If the client is directly injecting the dependency 
 * then client code is aware of the class dependencies.This tight coupling can be a problem if tomorrow the dependencies of the class changes.
 * Suppose if a X has a dependency on Y then without the container it is the responsibility of the client to create and inject the instance of class Y.
 */
namespace IOC_Through_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is IOC");
           
            var container = new UnityContainer();
           
           
           //creating object 
            container.RegisterType<IEmpDtls, DBRepository>();
            Employess emp= container.Resolve<Employess>();
            //IEmpDtls emp = new DBRepository();
            
            emp.GetData();
            Console.ReadKey();
        }
    }
}
