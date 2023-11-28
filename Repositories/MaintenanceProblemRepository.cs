using System.Collections.Generic;
using System.Threading.Tasks;
using LUSCMaintenance.Data;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using Microsoft.EntityFrameworkCore;

namespace LUSCMaintenance.Repositories
{
    public class MaintenanceProblemRepository : IMaintenanceProblemRepository
    {
        private readonly LUSCMaintenanceDbContext _dbContext;

        public MaintenanceProblemRepository(LUSCMaintenanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MaintenanceProblem>> GetMaintenanceProblemsAsync()
        {
            return await _dbContext.MaintenanceProblems
                .Include(mp => mp.MaintenanceIssue)
                .ToListAsync();
        }

        public async Task<MaintenanceProblem> GetMaintenanceProblemByIdAsync(int id)
        {
            return await _dbContext.MaintenanceProblems
                .Include(mp => mp.MaintenanceIssue)
                .FirstOrDefaultAsync(mp => mp.Id == id);
        }

        public async Task AddMaintenanceProblemAsync(MaintenanceProblem maintenanceProblem)
        {
            _dbContext.MaintenanceProblems.Add(maintenanceProblem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMaintenanceProblemAsync(MaintenanceProblem maintenanceProblem)
        {
            _dbContext.MaintenanceProblems.Update(maintenanceProblem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMaintenanceProblemAsync(int id)
        {
            var maintenanceProblem = await _dbContext.MaintenanceProblems.FindAsync(id);
            if (maintenanceProblem != null)
            {
                _dbContext.MaintenanceProblems.Remove(maintenanceProblem);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
