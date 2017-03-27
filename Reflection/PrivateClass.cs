using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class PrivateClass
    {
        private string PrivateProp { get; set; } = "No one can change me";

        private string privateField = "I am here now";

        private string PrivateMethod(string parameter1, string parameter2)
        {
            return $"You got me with {parameter1} and {parameter2}!";
        }

        private static string PrivateStaticMethod(string parameter1, string parameter2)
        {
            return $"You got me with {parameter1} and {parameter2} too!";
        }
    }
}
