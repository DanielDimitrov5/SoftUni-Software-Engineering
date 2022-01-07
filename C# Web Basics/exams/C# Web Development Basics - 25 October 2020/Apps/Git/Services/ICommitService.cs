using System.Collections.Generic;
using Git.Data.Models;
using Git.ViewModels;

namespace Git.Services
{
    public interface ICommitService
    {
        Repository GetRepositoryId(string id);

        string CreateCommit(string repositoryId,string userId, string description);

        IEnumerable<CommitViewModel> GetAllCommits(string userId);

        void DeleteCommit(string id);
    }
}