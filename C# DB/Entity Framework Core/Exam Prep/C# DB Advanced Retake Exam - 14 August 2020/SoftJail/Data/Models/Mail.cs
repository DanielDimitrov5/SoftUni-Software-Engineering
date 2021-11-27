using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Mail
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"^[\sA-z\d]+ str\.$")]
        public string Address { get; set; }

        [Required]
        public int PrisonerId { get; set; }

        [Required]
        public Prisoner Prisoner { get; set; }
    }
}