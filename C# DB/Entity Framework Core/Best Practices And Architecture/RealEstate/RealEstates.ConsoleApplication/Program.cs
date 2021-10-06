namespace RealEstates.ConsoleApplication
{
    using System;
    using System.Linq;
    using System.Text;

    using RealEstates.Data;
    using RealEstates.Services;

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var context = new RealEstateContext();

            Console.WriteLine("Select language for the option list:");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Bulgarian");

            bool parsedOption = int.TryParse(Console.ReadLine(), out int input);

            while (true)
            {
                Console.Clear();

                if (parsedOption)
                {
                    if (input == 1)
                    {
                        Console.WriteLine("Chose an option:");
                        Console.WriteLine("1. Property search:");
                        Console.WriteLine("2. District info:");
                        Console.WriteLine("3. Top districts by average price:");
                        Console.WriteLine("4. Districts with average price per m²:");
                        Console.WriteLine("5. Filter by tags:");
                        Console.WriteLine("0. EXIT");
                    }
                    else if (input == 2)
                    {
                        Console.WriteLine("Изберете опция:");
                        Console.WriteLine("1. Търсене на имущество:");
                        Console.WriteLine("2. Информация за кварталите:");
                        Console.WriteLine("3. Топ квартали по средна цена:");
                        Console.WriteLine("4. Квартали със средна цена за м²:");
                        Console.WriteLine("5. Филтриране по тагове:");
                        Console.WriteLine("0. ИЗХОД");
                    }
                    else
                    {
                        Console.WriteLine("Invalid option!");
                        break;
                    }
                }

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
                    case 4: DistrictWithAvgPricePerSquareMeter(context); break;
                    case 5: FilterByTag(context); break;
                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void FilterByTag(RealEstateContext context)
        {
            Console.WriteLine("Enter tags:");
            string tags = Console.ReadLine();

            IPropertiesService service = new PropertiesService(context);

            var properties = service.TagFilter(tags);

            foreach (var property in properties)
            {
                Console.WriteLine(property);
            }
        }

        private static void DistrictWithAvgPricePerSquareMeter(RealEstateContext context)
        {
            Console.WriteLine("District with average price per m²");

            IDistrictService service = new DistrictService(context);

            var districts = service.DistrictWithAveragePricePerSquareMeter();

            foreach (var district in districts.OrderByDescending(x => x.AveragePricePerSquareMeter))
            {
                Console.WriteLine(district);
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
                Console.WriteLine($"{++count}. {property}");
            }
        }
    }
}
