using System.ComponentModel.DataAnnotations;

namespace SocialMedia1.Data.Models
{
    public class UserProfile
    {
        [Key]
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Surename { get; set; }

        public string? City { get; set; }

        public DateTime Birthday { get; set; }

        public int Age => (int)((DateTime.Now - Birthday).Days / 365);

        public string? EmailAddress { get; set; }

        public string? Bio { get; set; }
    }
}
