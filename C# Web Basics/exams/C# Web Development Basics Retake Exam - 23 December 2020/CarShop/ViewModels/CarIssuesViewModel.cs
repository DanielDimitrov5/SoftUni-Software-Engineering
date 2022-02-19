using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class CarIssuesViewModel
    {
        public CarIssuesViewModel()
        {
            Issues = new HashSet<IssueViewModel>();
        }

        public string CarId { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Plate { get; set; }

        public ICollection<IssueViewModel> Issues { get; set; }
    }
}
