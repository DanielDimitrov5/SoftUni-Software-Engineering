using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Data
{
    public class Car
    {
        public Car()
        {
            Id = Guid.NewGuid().ToString();  
            Issues = new HashSet<Issue>();
        }

        public string Id { get; set; }

        [MinLength(5)]
        [MaxLength(20)]
        [Required]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        [Url]
        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}
