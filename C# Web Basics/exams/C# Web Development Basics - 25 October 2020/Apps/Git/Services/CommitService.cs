using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.ViewModels;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly ApplicationDbContext context;

        public CommitService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string CreateCommit(string repositoryId, string userId, string description)
        {
            Commit commit = new Commit
            {
                CreatorId = userId,
                Description = description,
                CreatedOn = DateTime.UtcNow,
                RepositoryId = repositoryId
            };

            context.Commits.Add(commit);

            context.SaveChanges();

            return commit.Id;
        }

        public void DeleteCommit(string id)
        {
            var commit = context.Commits.Find(id);

            context.Commits.Remove(commit);

            context.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAllCommits(string userId)
        {
            return context.Commits
                .Where(x=>x.CreatorId == userId)
                .Select(x => new CommitViewModel
            {
                Id = x.Id,
                Name = x.Repository.Name,
                Description = x.Description,
                Date = x.CreatedOn.ToString("g")
            }).ToArray();
        }

        public Repository GetRepositoryId(string id)
        {
            return context.Repositories.Find(id);
        }
    }
}