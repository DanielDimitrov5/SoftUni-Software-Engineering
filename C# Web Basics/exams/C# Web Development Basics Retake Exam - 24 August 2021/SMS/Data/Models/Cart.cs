using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models
{
    public class Cart
    {
        public Cart()
        {
            Products = new List<Product>();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }      

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
