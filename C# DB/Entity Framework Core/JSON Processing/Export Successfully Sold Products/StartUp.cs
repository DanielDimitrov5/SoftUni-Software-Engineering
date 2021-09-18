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

            string result = GetSoldProducts(context);

            Console.WriteLine(result);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ThenInclude(x => x.Buyer)
                .Where(x => x.ProductsSold.Count > 0 && x.ProductsSold.Any(b => b.Buyer != null))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold.Select(product => new
                    {
                        product.Name,
                        product.Price,
                        BuyerFirstName = product.Buyer.FirstName,
                        BuyerLastName = product.Buyer.LastName
                    })
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName);

            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(users,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = resolver
                });

            return json;
        }
    }
}