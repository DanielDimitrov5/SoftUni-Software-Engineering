using System.Linq;
using Git.Data;
using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService service;

        public CommitsController(ICommitService service)
        {
            this.service = service;
        }

        public HttpResponse All()
        {
            var userId = GetUserId();

            var commits = service.GetAllCommits(userId);

            return View(commits);
        }

        public HttpResponse Create(string id)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            var repository = service.GetRepositoryId(id);

            return View(repository);
        }

        [HttpPost]
        public HttpResponse Create(string id, CreateCommitViewModel model)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length < 5)
            {
                return Error("Description should be at least 5 characters long.");
            }

            service.CreateCommit(id, GetUserId(), model.Description);

            return Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            service.DeleteCommit(id);

            return Redirect("/Commits/All");
        }
    }
}