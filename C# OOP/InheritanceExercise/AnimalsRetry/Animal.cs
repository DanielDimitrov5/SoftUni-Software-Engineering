using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        { 
            get => name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }
                name = value;
            } 
        }

        public int Age
        {
            get => age;

            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
                {
                    throw new Exception("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender
        {
            get => gender;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid input!");
                }
                gender = value;
            }
        }

        public virtual void ProduceSound()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.Append($"{Name} {Age} {Gender}");

            return sb.ToString();
        }
    }
}
