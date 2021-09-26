using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Export;

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
                .Where(x => x.ProductsSold.Any())
                .Select(x => new ExportUsersDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(s => new ExportSoldProductsDto
                    {
                        Name = s.Name,
                        Price = s.Price
                    })
                        .ToArray()
                })
                .OrderBy(x=>x.LastName)
                .ThenBy(x=>x.FirstName)
                .Take(5)
                .ToArray();

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUsersDto[]), new XmlRootAttribute("Users"));

            serializer.Serialize(writer, users, ns);

            return writer.GetStringBuilder().ToString();
        }
    }
}