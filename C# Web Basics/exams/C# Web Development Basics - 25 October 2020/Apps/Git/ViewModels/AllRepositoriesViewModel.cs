using System.Collections.Generic;

namespace Git.ViewModels
{
    public class AllRepositoriesViewModel
    {
        public IEnumerable<RepositoryViewModel> Repositories { get; set; }
    }
}