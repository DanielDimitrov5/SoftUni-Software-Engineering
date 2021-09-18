using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            var json = File.ReadAllText("../../../Datasets/categories.json");

            string result = ImportCategories(context, json);

            Console.WriteLine(result);
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson).Where(x=>x.Name != null).ToArray();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
    }
}