using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private string name;

        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get => money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }
        public ICollection<Product> Bag { get; private set; }


        internal bool CanAfford(Product currentProduct)
        {
            if (money >= currentProduct.Cost)
            {
                return true;
            }

            return false;
        }

        internal void BuyProduct(Product currentProduct)
        {
            money -= currentProduct.Cost;

            Bag.Add(currentProduct);

            Console.WriteLine($"{name} bought {currentProduct.Name}");
        }
    }
}
