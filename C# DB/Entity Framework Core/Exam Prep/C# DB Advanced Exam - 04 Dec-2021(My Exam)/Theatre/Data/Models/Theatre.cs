using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public sbyte NumberOfHalls { get; set; }

        [Required]
        public string Director { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
    }
}