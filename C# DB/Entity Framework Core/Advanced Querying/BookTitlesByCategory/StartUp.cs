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

            string input = Console.ReadLine();

            string result = GetBooksByCategory(db, input);

            Console.WriteLine(result);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.BooksCategories
                .Where(x => categories.Any(c => c == x.Category.Name.ToLower()))
                .Select(x => x.Book.Title)
                .OrderBy(x => x);

            StringBuilder sb = new StringBuilder();

            foreach (var titles in books)
            {
                sb.AppendLine(titles);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
