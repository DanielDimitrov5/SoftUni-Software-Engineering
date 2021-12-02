using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ExportDto;
using SoftJail.DataProcessor;

namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                        .OrderByDescending(o => o.Book.Price)
                        .Select(b => new
                        {
                            BookName = b.Book.Name,
                            BookPrice = b.Book.Price.ToString("F2")
                        })
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(o => o.Books.Length)
                .ThenBy(o => o.AuthorName);

            string json = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books
                .ToArray()
                .Where(x => x.PublishedOn < date && x.Genre == Genre.Science)
                .OrderByDescending(o => o.Pages)
                .ThenByDescending(o => o.PublishedOn)
                .Select(x => new ExportBookDto
                {
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                    Pages = x.Pages
                })
                .Take(10)
                .ToArray();

            string xml = XmlConverter.Serialize(books, "Books");

            return xml;
        }
    }
}