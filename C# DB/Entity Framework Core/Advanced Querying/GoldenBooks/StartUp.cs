namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;

    using Data;
    using Initializer;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string result = GetGoldenBooks(db);

            Console.WriteLine(result);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(x => x.Copies < 5000 &&
                            x.EditionType == Enum.Parse<EditionType>("Gold")
                )
                .OrderBy(x => x.BookId)
                .Select(x => x.Title);

            StringBuilder sb = new StringBuilder();

            foreach (var bookTitle in goldenBooks)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
