using PizzaCalories.Exeptions;
using System;

namespace PizzaCalories
{
    class Topping
    {
        private const int minWeight = 1;
        private const int maxWeight = 50;

        private string type;
        private double weight;
        private double modifier = 2;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;

            switch (type.ToLower())
            {
                case "meat": modifier *= 1.2; break;
                case "veggies": modifier *= 0.8; break;
                case "cheese": modifier *= 1.1; break;
                case "sauce": modifier *= 0.9; break;
            }
        }

        public string Type
        {
            get => type;

            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.invalidTypeOfToppingExeption, value));
                }

                type = value;
            }
        }

        public double Weight
        {
            get => weight;

            private set
            {
                if (value < minWeight || value > maxWeight)
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.invalidWeightExeption, this.type, minWeight, maxWeight));
                }

                weight = value;
            }
        }

        public double GetCalories()
        {
            return weight * modifier;
        }
    }
}