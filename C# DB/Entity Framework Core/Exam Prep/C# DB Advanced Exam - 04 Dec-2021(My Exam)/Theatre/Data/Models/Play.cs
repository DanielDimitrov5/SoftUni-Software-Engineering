using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            Casts = new HashSet<Cast>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public float Rating { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Screenwriter { get; set; }

        public IEnumerable<Cast> Casts { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
    }
}