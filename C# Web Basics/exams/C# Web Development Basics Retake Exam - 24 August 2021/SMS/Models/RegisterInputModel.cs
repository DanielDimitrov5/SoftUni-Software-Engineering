using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class RegisterInputModel
    {
        [MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}