using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.ViewModels;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext context;

        public RepositoriesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(string name, string isPublic, string ownerId)
        {
            if (context.Repositories.Any(x => x.Name == name))
            {
                return;
            }

            Repository repository = new Repository
            {
                Name = name,
                IsPublic = isPublic == "Public",
                CreatedOn = DateTime.UtcNow,
                OwnerId = ownerId
            };

            context.Repositories.Add(repository);

            context.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAllRepositories()
        {
            var repos = context.Repositories
                .Where(x => x.IsPublic)
                .Select(x=> new RepositoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn.ToString("g"),
                CommitsCount = x.Commits.Count
            }).ToList();

            return repos;
        }
    }
}