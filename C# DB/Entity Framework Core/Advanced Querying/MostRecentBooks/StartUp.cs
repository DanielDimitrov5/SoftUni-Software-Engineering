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

            string result = GetMostRecentBooks(db);

            Console.WriteLine(result);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    TopBooks = x.CategoryBooks.Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate
                    }).OrderByDescending(y => y.ReleaseDate)
                        .Take(3)
                })
                .OrderBy(x => x.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.TopBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
