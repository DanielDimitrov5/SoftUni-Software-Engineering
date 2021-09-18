using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

           string result = GetProductsInRange(context);
            
            Console.WriteLine(result);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000).Select(x => new
                {
                    x.Name,
                    x.Price,
                    Seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.Price);

            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(products,
                new JsonSerializerSettings
                {

                    Formatting = Formatting.Indented,
                    ContractResolver = resolver
                });

            return json;
        }
    }
}