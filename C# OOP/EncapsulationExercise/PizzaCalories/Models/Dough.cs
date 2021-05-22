using System;

using PizzaCalories.Exeptions;

namespace PizzaCalories
{
    class Dough
    {
        private const int minDoughWeight = 1;
        private const int maxDoughWeight = 200;

        private string type;
        private string bakingTechnique;
        private double weight;
        private double modifier = 2;

        public Dough(string type, string bakingTechnique, double weight)
        {
            Type = type;
            BakingTechnique = bakingTechnique;
            Weight = weight;

            switch (type.ToLower())
            {
                case "white": modifier *= 1.5; break;
                case "wholegrain": modifier *= 1.0; break;
            }

            switch (bakingTechnique.ToLower())
            {
                case "crispy": modifier *= 0.9; break;
                case "chewy": modifier *= 1.1; break;
                case "homemade": modifier *= 1.0; break;
            }
        }

        public string Type
        {
            get => type;

            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(ExeptionMessages.invalidTypeOfDoughExeption);
                }

                type = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;

            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(ExeptionMessages.invalidTypeOfDoughExeption);
                }

                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => weight;

            private set
            {
                if (value < minDoughWeight || value > maxDoughWeight)
                {
                    throw new Exception(string.Format(ExeptionMessages.doughtWeightExeption, minDoughWeight, maxDoughWeight));
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