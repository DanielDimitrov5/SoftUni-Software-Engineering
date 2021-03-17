using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopList = new Dictionary<string, Dictionary<string, double>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] data = input.Split(", ");

                string shopName = data[0];
                string productName = data[1];
                double prise = double.Parse(data[2]);

                if (!shopList.ContainsKey(shopName))
                {
                    shopList.Add(shopName, new Dictionary<string, double>());
                }

                shopList[shopName].Add(productName, prise);
            }

            foreach (var shop in shopList.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
