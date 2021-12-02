using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b")]
        public string Email { get; set; }

        public BookDto[] Books { get; set; }
    }

    public class BookDto
    {
        [Required]
        public int? Id { get; set; }
    }
}