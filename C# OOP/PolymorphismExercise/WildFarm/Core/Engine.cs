using System;
using System.Collections.Generic;

using WildFarm.Contracts;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine
    {
        private ICollection<Animal> animals;

        public Engine()
        {
            animals = new List<Animal>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalsInfo = input.Split();

                Animal animal = CreateAnimal(animalsInfo);

                animals.Add(animal);

                string[] foodInfo = Console.ReadLine().Split();

                Food food = CreateFood(foodInfo);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }

        public Animal CreateAnimal(string[] animalsInfo)
        {
            string animalType = animalsInfo[0];
            string name = animalsInfo[1];
            double weight = double.Parse(animalsInfo[2]);

            Animal animal = null;

            switch (animalType)
            {
                case "Owl":

                    double wingSizeOwl = double.Parse(animalsInfo[3]);

                    animal = new Owl(name, weight, wingSizeOwl);
                    break;
                case "Hen":

                    double wingSizeHen = double.Parse(animalsInfo[3]);

                    animal = new Hen(name, weight, wingSizeHen);
                    break;
                case "Mouse":

                    string livingRegionMouse = animalsInfo[3];

                    animal = new Mouse(name, weight, livingRegionMouse);
                    break;
                case "Dog":

                    string livingRegionDog = animalsInfo[3];

                    animal = new Dog(name, weight, livingRegionDog);
                    break;
                case "Cat":

                    string livingRegionCat = animalsInfo[3];
                    string breedCat = animalsInfo[4];

                    animal = new Cat(name, weight, livingRegionCat, breedCat);
                    break;
                case "Tiger":

                    string livingRegionTiger = animalsInfo[3];
                    string breedTiger = animalsInfo[4];

                    animal = new Tiger(name, weight, livingRegionTiger, breedTiger);
                    break;
            }

            return animal;
        }

        private Food CreateFood(string[] foodInfo)
        {
            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            Food food = null;

            switch (foodType)
            {
                case "Vegetable": food = new Vegetable(quantity); break;
                case "Fruit": food = new Fruit(quantity); break;
                case "Meat": food = new Meat(quantity); break;
                case "Seeds": food = new Seeds(quantity); break;
            }

            return food;
        }

    }
}
