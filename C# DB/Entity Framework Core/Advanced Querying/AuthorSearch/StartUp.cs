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

            string result = GetAuthorNamesEndingIn(db, input);

            Console.WriteLine(result);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + " " + x.LastName)
                .OrderBy(x => x);

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine(author);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
