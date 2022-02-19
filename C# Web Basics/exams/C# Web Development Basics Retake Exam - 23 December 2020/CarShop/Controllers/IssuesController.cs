using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;
        private readonly IUserService userService;

        public IssuesController(IIssueService issueService, IUserService userService)
        {
            this.issueService = issueService;
            this.userService = userService;
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var model = issueService.GetAllIssues(carId);

            return View(model);
        }

        public HttpResponse Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Add(string carId, string description)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            if (description.Length < 5)
            {
                return Error("Description should be at least 5 characters long!");
            }

            issueService.AddIssue(carId, description);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public HttpResponse Delete(string issueId, string carId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            issueService.DeleteIssue(issueId);

            return Redirect($"/Issues/CarIssues?CarId={carId}");
        }

        public HttpResponse Fix(string issueId, string carId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            if (!userService.IsMechanic(User.Id))
            {
                return Error("Only mechanics can fix issues!");
            }

            issueService.FixIssue(issueId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
