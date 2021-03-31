namespace FilterByAge
{
    using System;
    using System.Linq;

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] data = input.Split(", ");

                people[i] = new Person();

                people[i].Name = data[0];
                people[i].Age = int.Parse(data[1]);
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());

            Func<Person, bool> conditionFunc = GetCondition(condition, ageFilter);

            string printFormat = Console.ReadLine();

            Action<Person> printFormatFunc = GetPrintFormat(printFormat);

            Printer(people, conditionFunc, printFormatFunc);
        }

        private static void Printer(Person[] people, Func<Person, bool> conditionFunc, Action<Person> printFormatFunc)
        {
            foreach (var person in people.Where(conditionFunc))
            {
                printFormatFunc(person);
            }
        }

        static Action<Person> GetPrintFormat(string printFormat)
        {
            switch (printFormat)
            {
                case "name": return p => Console.WriteLine($"{p.Name}");
                case "age": return p => Console.WriteLine($"{p.Age}");
                case "name age": return p => Console.WriteLine($"{p.Name} - {p.Age}");
                default: return null;
            }
        }

        private static Func<Person, bool> GetCondition(string condition, int ageFilter)
        {
            switch (condition)
            {
                case "younger": return x => x.Age < ageFilter;
                case "older": return x => x.Age >= ageFilter;
                default: return null;
            }
        }
    }
}
