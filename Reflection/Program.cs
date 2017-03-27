using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Program
    {
        public enum BuildingType
        {
            [Description("Swimming pool")]
            Pool,
            [Description("Household")]
            House,
            [Description("Shopping mall")]
            Mall,
            [Description("Office building")]
            Office
        }

        static void Main(string[] args)
        {
            var privateClass = new PrivateClass();
            
            //Fields
            Console.WriteLine(Solution.GetFieldValue<string>(privateClass, "privateField"));

            Solution.SetFieldValue(privateClass, "privateField", "I took over.");

            Console.WriteLine(Solution.GetFieldValue<string>(privateClass, "privateField"));


            //Properties
            Console.WriteLine(Solution.GetPropertyValue<string>(privateClass, "PrivateProp"));

            Solution.SetPropertyValue(privateClass, "PrivateProp", "I took over.");

            Console.WriteLine(Solution.GetPropertyValue<string>(privateClass, "PrivateProp"));

            //Methods
            Console.WriteLine(Solution.InvokeMethod(privateClass, "PrivateMethod", "1", "2"));

            Console.WriteLine(Solution.InvokeStaticMethod(typeof(PrivateClass), "PrivateStaticMethod", "1", "2"));

            Console.ReadLine();

            //Getting attributes
            Console.WriteLine($"I was in the {BuildingType.Pool.GetDescription()}.");

            Console.ReadLine();

            //Real stuff
            var demanding =  new DemandingClass();

            //this fails horribly
            //demanding.Perform();

            Solution.SatisfyTheClass(demanding);

            //this works
            demanding.Perform();
            Console.ReadLine();
        }
    }
}
