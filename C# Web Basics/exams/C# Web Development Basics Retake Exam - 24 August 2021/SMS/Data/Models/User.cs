using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyWebServer.Identity;

namespace SMS.Models
{
    public class User : UserIdentity
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string CartId { get; set; }

        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
    }
}
