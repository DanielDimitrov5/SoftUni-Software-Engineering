using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        public int PrisonerId { get; set; }
        [Required]
        public Prisoner Prisoner { get; set; }

        public int OfficerId { get; set; }
        [Required]
        public Officer Officer { get; set; }
    }
}