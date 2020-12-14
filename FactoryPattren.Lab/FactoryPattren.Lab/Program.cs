using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattren.Lab
{
    //************************************   Problem************************************//
    /*First we have lots of ‘new’ keyword scattered in the client. In other ways the client is loaded with lot of object creational activities
     * which can make the client logic very complicated(object creation need to centralize and instantiation take by another). 
     * Second issue is that the client needs to be aware of all types of invoices. 
     * So if we are adding one more invoice class type called as ‘InvoiceWithFooter’ 
     * we need to reference the new class in the client and recompile the client also.(need to introduce interfaces. So client ref with interface)
     */
    //**********************************   Solution ********************************//
    /*  Factory pattern is one of the types of creational patterns.centralize creation of objects.
     *  Based on user input we will instantiate object at runtime when it is required.
     *  This eliminates the need for an application object(client) to deal with the varying class selection criteria.
     * https://www.dotnettricks.com/learn/designpatterns/factory-method-design-pattern-dotnet
     * https://www.codeproject.com/Articles/28309/Design-pattern-FAQ-Part-Training#Canyouexplainfactorypattern
     * ************************************Reflection solution**************************
     * if class is static and in future it doesn't change we can use factory class method.
     * in future is there any to add or extend we can use reflection because no need to complie once again factory. ref please check discussion notes
     */

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to second hand bikes showroom");
            Console.WriteLine("Available bike are \n 1.Pulsar\n2.Appache\n3. HeroHonda \n Please select what do you want to know price");
            int _intUserSelection = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter year model");
            int _intUserYearSelection = Convert.ToInt32(Console.ReadLine());
            /*If we observe we are instiating object based on user input. But today three bikes are there if in future any another bike add
             *  we need to change UI and corresponed class. Because it is tightly coupled with lower level class. 
             * And according our IOC object intialization need to invert. 
             */

            //if (_intUserSelection == 1) {
            //    Pulsar _obj = new Pulsar();
            //    Console.WriteLine("Original Price " + _obj.OriginalPrice);
            //    Console.WriteLine("\nDiscount on bike price is" + _obj.GetPrice(_intUserYearSelection));
            //}
            //else if (_intUserSelection == 2) {
            //    Appache _obj = new Appache();
            //    Console.WriteLine("Original Price " + _obj.AppacheOriginalPrice);
            //    Console.WriteLine("\nDiscount on bike price is" + _obj.GetPrice(_intUserYearSelection));
            //} else if (_intUserSelection==3) {
            //    HeroHonda _obj = new HeroHonda();
            //    Console.WriteLine("Original Price " + _obj.HHOriginalPrice);
            //    Console.WriteLine("\nDiscount on bike price is" + _obj.GetPrice(_intUserYearSelection));
            //}


            LoadTypesICanReturn();
            //*********************************Solution ************************************//
            void LoadTypesICanReturn()
            {
                Dictionary<string, Type> vehicles = new Dictionary<string, Type>();
                Type[] typeInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();
                foreach (Type type in typeInThisAssembly)
                {
                    if (type.GetInterface(typeof(IVehicals).ToString()) != null)
                    {
                        vehicles.Add(type.Name.ToLower(), type);
                    }
                }
            }

            IVehicals Factory = VehicalFactory.GetObject(_intUserSelection);
            Console.WriteLine("Original Price " + Factory.Original_Price);
            Console.WriteLine("\nDiscount on bike price is" + Factory.GetPrice(_intUserYearSelection));
            Console.ReadKey();
        }
    }
}
