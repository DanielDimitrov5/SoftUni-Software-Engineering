using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using SoftJail.DataProcessor;
using Theatre.DataProcessor.ExportDto;

namespace Theatre.DataProcessor
{
    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres.ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count() >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets
                        .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Sum(ti => ti.Price),
                    Tickets = x.Tickets
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Select(t => new
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    })
                        .OrderByDescending(o => o.Price)
                })
                .OrderByDescending(o => o.Halls)
                .ThenBy(o => o.Name);

            string json = JsonConvert.SerializeObject(theatres, Formatting.Indented, new DecimalFormatConverter());

            return json;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .Where(x => x.Rating <= rating)
                .OrderBy(o => o.Title)
                .ThenByDescending(o => o.Genre)
                .Select(x => new ExportPlayDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                        .Where(a => a.IsMainCharacter)
                        .Select(a => new ExportActorDto
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{a.Play.Title}'."
                        })
                        .OrderByDescending(o => o.FullName)
                        .ToArray()
                })
                .ToArray();

            string xml = XmlConverter.Serialize(plays, "Plays");

            return xml;
        }

        public class DecimalFormatConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(decimal);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteRawValue($"{value:0.00}");
            }

            public override bool CanRead => false;

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

    }
}
