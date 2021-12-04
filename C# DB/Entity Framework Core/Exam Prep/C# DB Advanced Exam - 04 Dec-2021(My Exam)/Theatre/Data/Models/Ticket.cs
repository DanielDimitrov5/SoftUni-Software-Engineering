using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }

        public Play Play { get; set; }

        public int TheatreId { get; set; }

        public Theatre Theatre { get; set; }
    }
}