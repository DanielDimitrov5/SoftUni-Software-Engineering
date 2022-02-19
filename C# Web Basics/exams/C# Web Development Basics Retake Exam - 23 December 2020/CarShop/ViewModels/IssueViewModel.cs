using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class IssueViewModel
    {
        public string IssueId { get; set; }

        public string CarId { get; set; }

        public string IsFixed { get; set; }

        public string Description { get; set; }
    }
}
