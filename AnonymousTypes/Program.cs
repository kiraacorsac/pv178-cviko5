using System;

namespace AnonymousTypes
{
    /// <summary>
    /// All credit goes to Rudolf Wittner, author of this demo sample
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Initialization1();
            Initialization2();

        }

        /// <summary>
        /// Ukazka inicializacie objektov
        /// </summary>
        private static void Initialization1()
        {
            var person = new Person(1, "marek");

            //pro tento zpusob inicializacie musi existovat bezparametricky konstruktor
            var person2 = new Person 
            {
                Name = "Herman",
                Age = 24
            };

            var persons = new[]
            {
                new Person(14, "abraham"),
                new Person(12, "matus")
            };
        }

        /// <summary>
        /// ukazka inicializacie objektov anonymneho typu
        /// </summary>
        private static void Initialization2()
        {
            var person0 = new Person(1, "marek");
            Console.WriteLine(person0);

            // inicializace anonymniho typu - jde o Person ???
            var person1 = new { Name = "klement", Age = 64 };
            Console.WriteLine(person1);
            Console.WriteLine("----------------");

            //jak vie ze su vsetky rovnakeho typu?
            var persons = new[]
            {
                new{Name = "teodor", Age = 42},
                new{Name = "hugo", Age = 38},
                new{Name = "mucha", Age = 10},
            };

            //jakto ze persons2 su ineho typu ako persons?
            var persons2 = new[]
            {
                new{Age = 42, Name = "teodor"},
                new{Age = 38, Name = "hugo"},
                new{Age = 10, Name = "mucha"},
            };

            foreach (var person in persons)
            {
                Console.WriteLine("{0} is {1} years old.", person.Name, person.Age);
            }

            Console.ReadKey();
        }

        // dobrej clanek na toto tema:
        // http://geekswithblogs.net/BlackRabbitCoder/archive/2012/06/21/c.net-little-wonders-the-joy-of-anonymous-types.aspx
    }
}
