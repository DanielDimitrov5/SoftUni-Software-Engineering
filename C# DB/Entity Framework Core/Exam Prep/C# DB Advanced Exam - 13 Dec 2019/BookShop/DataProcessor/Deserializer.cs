using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;
using SoftJail.DataProcessor;

namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            List<Book> books = new List<Book>();

            ImportBookDto[] bookDtos = XmlConverter.Deserializer<ImportBookDto>(xmlString, "Books");

            foreach (var bookDto in bookDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = DateTime.ParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));

                books.Add(book);
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<Author> authors = new List<Author>();

            var authorDtos = JsonConvert.DeserializeObject<IEnumerable<ImportAuthorDto>>(jsonString);

            foreach (var authorDto in authorDtos)
            {
                if (!IsValid(authorDto) || authors.Any(x => x.Email == authorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone
                };

                foreach (var bookDto in authorDto.Books)
                {
                    if (context.Books.Any(x => x.Id == bookDto.Id))
                    {
                        author.AuthorsBooks.Add(new AuthorBook { Book = context.Books.Find(bookDto.Id) });
                    }
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string FullName = author.FirstName + " " + author.LastName;

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, FullName, author.AuthorsBooks.Count));

                authors.Add(author);
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}