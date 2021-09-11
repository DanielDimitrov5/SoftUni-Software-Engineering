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

            string result = CountCopiesByAuthor(db);

            Console.WriteLine(result);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Copies = x.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(x => x.Copies);

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.AuthorName} - {author.Copies}");
            }

            return sb.ToString();
        }
    }
}
