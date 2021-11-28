using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^([A-Z]+|[a-z]+)\d*$")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}