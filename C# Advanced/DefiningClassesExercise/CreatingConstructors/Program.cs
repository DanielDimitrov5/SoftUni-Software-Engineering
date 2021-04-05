using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person(4);
            Person person3 = new Person("stefan", 12);

            List<Person> people = new List<Person>();

            people.Add(person1);
            people.Add(person2);
            people.Add(person3);

            foreach (var item in people)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
