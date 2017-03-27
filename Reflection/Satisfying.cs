using System;

namespace Reflection
{
    public class ExportAttribute : Attribute
    {
    }

    public class ImportAttribute : Attribute
    {
    }

    [Export]
    public class DemandedClass
    {
        public void DoStuff() => Console.WriteLine("DemandedClass Did stuff");
    }

    public class DemandingClass
    {
        [Import]
        private DemandedClass demandedClass;

        public void Perform()
        {
            Console.WriteLine("DemandingClass Did stuff");
            demandedClass.DoStuff();
        }
    }
}