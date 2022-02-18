using System.Collections.Generic;

namespace SMS.Models
{
    public class LoggedInIndexViewModel
    {
        public string Username { get; set; }
        
        public ICollection<ProductViewModel> Products { get; set; }
    }
}
