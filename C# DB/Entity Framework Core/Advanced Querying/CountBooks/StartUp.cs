namespace BookShop
{
    using System;
    using System.Linq;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            int lengthCheck = int.Parse(Console.ReadLine());

            int result = CountBooks(db, lengthCheck);

            Console.WriteLine(result);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookCount = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .ToList()
                .Count;

            return bookCount;
        }
    }
}
