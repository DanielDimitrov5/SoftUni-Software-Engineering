using System;

namespace OldestFamilyMember
{
    public class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] people = Console.ReadLine().Split();

                string name = people[0];
                int age = int.Parse(people[1]);

                Person member = new Person(name, age);

                family.AddMember(member);
            }

            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
