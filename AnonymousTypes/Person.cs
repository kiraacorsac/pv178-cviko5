namespace AnonymousTypes
{
    /// <summary>
    /// Based on Rudolf Wittner demo sample
    /// </summary>
    public class Person
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public Person() { }

        public Person(int age, string name)
        {
            Name = name;
            Age = age;
        }

        /// <summary>
        /// just another expression bodied function
        /// </summary>
        public bool IsAdult => this.Age > 18;

        public override string ToString()
        {
            return $"{this.Name} is {this.Age} years old.";
        }
    }
}
