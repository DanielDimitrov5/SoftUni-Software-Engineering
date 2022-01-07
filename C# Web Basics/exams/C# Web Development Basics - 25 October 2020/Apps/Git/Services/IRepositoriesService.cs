using System.Collections.Generic;
using Git.ViewModels;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void Create(string name, string isPublic, string ownerId);

        IEnumerable<RepositoryViewModel> GetAllRepositories();
    }
}