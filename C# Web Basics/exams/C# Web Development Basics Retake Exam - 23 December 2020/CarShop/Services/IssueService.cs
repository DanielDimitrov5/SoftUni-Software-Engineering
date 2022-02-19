using CarShop.Data;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class IssueService : IIssueService
    {
        private readonly ApplicationDbContext context;

        public IssueService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddIssue(string carId, string description)
        {
            Issue issue = new Issue
            {
                CarId = carId,
                Description = description
            };

            context.Issues.Add(issue);

            context.SaveChanges();
        }

        public void DeleteIssue(string issueId)
        {
            var issue = context.Issues.FirstOrDefault(x => x.Id == issueId);

            context.Issues.Remove(issue);

            context.SaveChanges();
        }

        public void FixIssue(string issueId)
        {
            var issue = context.Issues.FirstOrDefault(x => x.Id == issueId);

            issue.IsFixed = true;

            context.SaveChanges();
        }

        public CarIssuesViewModel GetAllIssues(string carId)
        {
            var car = context.Cars.FirstOrDefault(x => x.Id == carId);

            context.Entry(car).Collection(x => x.Issues).Load();
                
            var issue = new CarIssuesViewModel
            {
                CarId = carId,
                Model = car.Model,
                Plate = car.PlateNumber,
                Year = car.Year,
                Issues = car.Issues.Select(x => new IssueViewModel
                {
                    IsFixed = x.IsFixed ? "Yes" : "Not yet",
                    Description = x.Description,
                    IssueId = x.Id,
                    CarId = carId,
                })
                .ToArray()
            };

            return issue;
        }
    }
}
