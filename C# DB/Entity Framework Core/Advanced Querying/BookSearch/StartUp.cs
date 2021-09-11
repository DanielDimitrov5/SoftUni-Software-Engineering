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

            string result = GetBookTitlesContaining(db, input);

            Console.WriteLine(result);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x);

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
