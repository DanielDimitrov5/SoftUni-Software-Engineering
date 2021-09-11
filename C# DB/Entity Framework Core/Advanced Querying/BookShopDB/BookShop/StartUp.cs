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
            DbInitializer.ResetDatabase(db);

            string command = Console.ReadLine();

            string result = GetBooksByAgeRestriction(db, command);

            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = default;

            switch (command.ToLower())
            {
                case "minor": ageRestriction = AgeRestriction.Minor; break;
                case "teen": ageRestriction = AgeRestriction.Teen; break;
                case "adult": ageRestriction = AgeRestriction.Adult; break;

            }

            var books = context.Books.Where(x => x.AgeRestriction == ageRestriction).Select(x => new { x.Title }).OrderBy(x => x.Title);

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
