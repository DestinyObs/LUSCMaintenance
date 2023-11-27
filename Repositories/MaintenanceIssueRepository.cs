using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LUSCMaintenance.Data;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;

namespace LUSCMaintenance.Repositories
{
    public class MaintenanceIssueRepository : IMaintenanceIssueRepository
    {
        private readonly LUSCMaintenanceDbContext _dbContext;

        public MaintenanceIssueRepository(LUSCMaintenanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MaintenanceIssue>> GetMaintenanceIssuesAsync()
        {
            return await _dbContext.MaintenanceIssues
                .Include(issue => issue.MaintenanceIssueCategory)
                .ToListAsync();
        }

        public async Task<MaintenanceIssue> GetMaintenanceIssueByIdAsync(int id)
        {
            return await _dbContext.MaintenanceIssues
                .Include(issue => issue.MaintenanceIssueCategory)
                .FirstOrDefaultAsync(issue => issue.Id == id);
        }
        public async Task<IEnumerable<MaintenanceIssue>> GetMaintenanceIssuesByCategoryAsync(int categoryId)
        {
            return await _dbContext.MaintenanceIssues
                .Where(issue => issue.MaintenanceIssueCategoryId == categoryId)
                .ToListAsync();
        }


        public async Task AddMaintenanceIssueAsync(MaintenanceIssue maintenanceIssue)
        {
            _dbContext.MaintenanceIssues.Add(maintenanceIssue);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMaintenanceIssueAsync(MaintenanceIssue maintenanceIssue)
        {
            _dbContext.Entry(maintenanceIssue).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMaintenanceIssueAsync(int id)
        {
            var issue = await _dbContext.MaintenanceIssues.FindAsync(id);
            if (issue != null)
            {
                _dbContext.MaintenanceIssues.Remove(issue);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
