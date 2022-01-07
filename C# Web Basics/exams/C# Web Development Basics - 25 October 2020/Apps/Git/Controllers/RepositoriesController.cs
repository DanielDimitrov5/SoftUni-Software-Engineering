using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService service;

        public RepositoriesController(IRepositoriesService service)
        {
            this.service = service;
        }

        public HttpResponse Create()
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel model)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                return Error("Name should be between 3 and 10 characters.");
            }

            service.Create(model.Name, model.RepositoryType, this.GetUserId());

            return Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var repos = new AllRepositoriesViewModel
            {
                Repositories = service.GetAllRepositories()
            };

            return View(repos);
        }
    }
}