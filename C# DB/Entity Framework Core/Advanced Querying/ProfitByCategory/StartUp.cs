namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string result = GetTotalProfitByCategory(db);

            Console.WriteLine(result);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Proffit = x.CategoryBooks.Select(b => new
                    {
                        b.Book.Price,
                        b.Book.Copies
                    }).Sum(s => s.Copies * s.Price)
                })
                .OrderByDescending(x => x.Proffit)
                .ThenBy(x => x.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Proffit:F2}");
            }

            return sb.ToString();
        }
    }
}
