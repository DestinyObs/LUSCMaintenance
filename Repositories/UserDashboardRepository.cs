using LUSCMaintenance.Data;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUSCMaintenance.Repositories
{
    public class UserDashboardRepository : IUserDashboardRepository
    {
        private readonly LUSCMaintenanceDbContext _dbContext;

        public UserDashboardRepository(LUSCMaintenanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MaintenanceProblem>> GetIssuesByUserIdAsync(string webmail)
        {
            return await _dbContext.MaintenanceProblems
                .Where(p => p.WebMail == webmail)
                .ToListAsync();
        }

        public async Task<MaintenanceProblem> GetIssueByIdAsync(int issueId)
        {
            return await _dbContext.MaintenanceProblems
                .FirstOrDefaultAsync(p => p.Id == issueId);
        }

        public async Task<bool> UpdateIssueAsync(int issueId, MaintenanceProblem updatedIssue)
        {
            var issueToUpdate = await _dbContext.MaintenanceProblems.FindAsync(issueId);
            if (issueToUpdate == null)
                return false;

            issueToUpdate.Description = updatedIssue.Description;
            issueToUpdate.Status = updatedIssue.Status;

            _dbContext.MaintenanceProblems.Update(issueToUpdate);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIssueAsync(int issueId)
        {
            var issueToDelete = await _dbContext.MaintenanceProblems.FindAsync(issueId);
            if (issueToDelete == null)
                return false;

            _dbContext.MaintenanceProblems.Remove(issueToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<MaintenanceProblem>> FilterIssuesByDateAsync(DateTime date)
        {
            return await _dbContext.MaintenanceProblems
                .Where(p => p.DateComplaintMade.Date == date.Date) 
                .ToListAsync();
        }

        public async Task<List<MaintenanceProblem>> FilterIssuesByTypeAsync(string issueType)
        {
            return await _dbContext.MaintenanceProblems
                .Where(p => p.MaintenanceIssue.Description == issueType)
                .ToListAsync();
        }

        public async Task<List<MaintenanceProblem>> FilterIssuesByStatusAsync(string status)
        {
            return await _dbContext.MaintenanceProblems
                .Where(p => p.Status == status)
                .ToListAsync();
        }
    }
}
