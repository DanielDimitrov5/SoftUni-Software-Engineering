using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            string xml = File.ReadAllText("Datasets/categories.xml");

            string result = ImportCategories(context, xml);

            Console.WriteLine(result);
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var reader = new StringReader(inputXml);

            var categoryDtos = (ImportCategoryDto[])serializer.Deserialize(reader);

            var categories = categoryDtos
                .Select(x => new Category
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            foreach (Category category in categories)
            {
                if (category.Name != null)
                {
                    context.Categories.Add(category);
                }
            }

            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
    }
}