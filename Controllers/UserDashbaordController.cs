//using LUSCMaintenance.Data;
//using LUSCMaintenance.Interfaces;
//using LUSCMaintenance.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace LUSCMaintenance.Repositories
//{
//    public class UserDashboardRepository : IUserDashboardRepository
//    {
//        private readonly LUSCMaintenanceDbContext _dbContext;

//        public UserDashboardRepository(LUSCMaintenanceDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<List<MaintenanceProblem>> GetIssuesByUserIdAsync(int userId)
//        {
//            return await _dbContext.MaintenanceProblems
//                .Where(p => p.WebMail == userId.ToString())
//                .ToListAsync();
//        }

//        public async Task<MaintenanceProblem> GetIssueByIdAsync(int issueId)
//        {
//            return await _dbContext.MaintenanceProblems.FindAsync(issueId);
//        }

//        public async Task<bool> UpdateIssueAsync(int issueId, MaintenanceProblem updatedIssue)
//        {
//            var issue = await _dbContext.MaintenanceProblems.FindAsync(issueId);
//            if (issue == null)
//                return false;

//            issue.IsResolved = updatedIssue.IsResolved; // Update other properties as needed

//            _dbContext.MaintenanceProblems.Update(issue);
//            await _dbContext.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> DeleteIssueAsync(int issueId)
//        {
//            var issue = await _dbContext.MaintenanceProblems.FindAsync(issueId);
//            if (issue == null)
//                return false;

//            _dbContext.MaintenanceProblems.Remove(issue);
//            await _dbContext.SaveChangesAsync();
//            return true;
//        }

//        public async Task<List<MaintenanceProblem>> FilterIssuesByDateAsync(DateTime date)
//        {
//            return await _dbContext.MaintenanceProblems
//                .Where(p => p.DateComplaintMade.Date == date.Date)
//                .ToListAsync();
//        }

//        public async Task<List<MaintenanceProblem>> FilterIssuesByTypeAsync(string issueType)
//        {
//            return await _dbContext.MaintenanceProblems
//                .Where(p => p.MaintenanceIssueCategory.Name == issueType)
//                .ToListAsync();
//        }

//        public async Task<List<MaintenanceProblem>> FilterIssuesByStatusAsync(string status)
//        {
//            bool isResolved = status.ToLower() == "resolved";
//            return await _dbContext.MaintenanceProblems
//                .Where(p => p.IsResolved == isResolved)
//                .ToListAsync();
//        }
//    }
//}
