using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public interface IIssueService
    {
        CarIssuesViewModel GetAllIssues(string carId);

        void AddIssue(string carId, string description);

        void DeleteIssue(string issueId);

        void FixIssue(string issueId);
    }
}
