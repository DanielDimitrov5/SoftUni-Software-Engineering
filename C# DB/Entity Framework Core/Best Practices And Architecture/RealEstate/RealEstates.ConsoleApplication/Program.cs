using System;
using System.Linq;
using System.Text;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var context = new RealEstateContext();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Chose an option:");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. District info");
                Console.WriteLine("3. Top districts by average price");
                Console.WriteLine("0. EXIT");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);

                if (parsed && option == 0)
                {
                    break;
                }

                switch (option)
                {
                    case 1: PropertySearch(context); break;
                    case 2: DistrictInfo(context); break;
                    case 3: TopDistrictsByAveragePrice(context); break;
                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void TopDistrictsByAveragePrice(RealEstateContext context)
        {
            Console.Write("Select top: ");
            int n = int.Parse(Console.ReadLine());

            IDistrictService service = new DistrictService(context);

            var districts = service.DistrictsInfo().OrderByDescending(x => x.AveragePrice).Take(n).ToList();

            int count = 0;

            foreach (var district in districts)
            {
                Console.WriteLine($"{++count}. {district}");
            }
        }

        private static void DistrictInfo(RealEstateContext context)
        {
            IDistrictService service = new DistrictService(context);

            var districts = service.DistrictsInfo();

            int count = 0;

            foreach (var district in districts.OrderByDescending(x => x.AveragePrice))
            {
                Console.WriteLine($"{++count}. {district}");
            }
        }

        private static void PropertySearch(RealEstateContext context)
        {
            Console.Write("Min price:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price:");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.Write("Min size:");
            int minSize = int.Parse(Console.ReadLine());
            Console.Write("Max size:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(context);

            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);

            int count = 0;

            foreach (var property in properties.Where(x => x.Price > 0))
            {
                Console.WriteLine($"{++count}. {property.DistrictName}: Price: {property.Price}€ -> Size: {property.Size}, Property type: {property.PropertyType}, Property building type: {property.BuildingType}");
            }
        }
    }
}
