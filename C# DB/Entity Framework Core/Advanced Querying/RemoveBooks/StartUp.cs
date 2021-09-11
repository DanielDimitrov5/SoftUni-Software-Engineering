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

            int result = RemoveBooks(db);

            Console.WriteLine(result);
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }
    }
}
