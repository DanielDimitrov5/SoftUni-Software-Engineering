using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.05", "1000")]
        public decimal Price { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
