using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Data
{
    public class Issue
    {
        public Issue()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [MinLength(5)]
        [Required]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        [Required]
        public string CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
