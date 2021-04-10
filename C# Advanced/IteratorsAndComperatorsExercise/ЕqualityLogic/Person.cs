using System;

namespace IteratorsAndComeparators
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            Person person = (Person)obj;

            if ((obj == null) || !GetType().Equals(person.GetType()))
            {
                return false;
            }

            return Name == person.Name && Age == person.Age;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() / 3 + Age.GetHashCode() * 2;
        }
    }
}