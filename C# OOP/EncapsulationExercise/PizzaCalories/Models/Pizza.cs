using PizzaCalories.Exeptions;
using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException(ExeptionMessages.invalidNameExeption);
                }

                name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);

            if (toppings.Count > 10)
            {
                throw new ArgumentException(ExeptionMessages.invalidNumberOfToppingsExeption);
            }
        }

        public double GetCalories()
        {
            double calories = 0;

            foreach (var top in toppings)
            {
                calories += top.GetCalories();
            }

            return dough.GetCalories() + calories;
        }

        public override string ToString()
        {
            return $"{Name} - {GetCalories():F2} Calories.";
        }
    }
}
