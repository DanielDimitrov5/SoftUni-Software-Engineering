using MyWebServer.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class User : UserIdentity
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserTrips = new HashSet<UserTrip>();
        }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
