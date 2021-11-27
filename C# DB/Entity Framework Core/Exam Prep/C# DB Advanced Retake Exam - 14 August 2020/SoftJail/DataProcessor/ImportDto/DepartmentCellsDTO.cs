using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentCellsDTO

    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public List<CellDTO> Cells { get; set; }
    }

    public class CellDTO
    {
        [Range(1, 1000)]
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}