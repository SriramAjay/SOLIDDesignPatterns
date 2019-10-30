using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FactoryPattrenWithReference
{
    class FactoryWithReflection
    {
        public static IAnimalInfo GetObject(string AnimalName) {

            //var assembly = Assembly.GetExecutingAssembly();
            //var type = assembly.GetType(AnimalName).FullName;
            //return (IAnimalInfo)Activator.CreateInstanceFrom(assembly.Location, type).Unwrap();

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == AnimalName);
            return (IAnimalInfo)Activator.CreateInstance(currentType);


        }
    }
}
