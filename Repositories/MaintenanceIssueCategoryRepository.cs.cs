using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LUSCMaintenance.Data;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;

namespace LUSCMaintenance.Repositories
{
    public class MaintenanceIssueCategoryRepository : IMaintenanceIssueCategoryRepository
    {
        private readonly LUSCMaintenanceDbContext _dbContext;

        public MaintenanceIssueCategoryRepository(LUSCMaintenanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MaintenanceIssueCategory>> GetMaintenanceIssueCategoriesAsync()
        {
            return await _dbContext.MaintenanceIssueCategories.ToListAsync();
        }

        public async Task<MaintenanceIssueCategory> GetMaintenanceIssueCategoryByIdAsync(int id)
        {
            return await _dbContext.MaintenanceIssueCategories.FindAsync(id);
        }

        public async Task AddMaintenanceIssueCategoryAsync(MaintenanceIssueCategory maintenanceIssueCategory)
        {
            _dbContext.MaintenanceIssueCategories.Add(maintenanceIssueCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMaintenanceIssueCategoryAsync(MaintenanceIssueCategory maintenanceIssueCategory)
        {
            _dbContext.Entry(maintenanceIssueCategory).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMaintenanceIssueCategoryAsync(int id)
        {
            var maintenanceIssueCategory = await _dbContext.MaintenanceIssueCategories.FindAsync(id);
            if (maintenanceIssueCategory != null)
            {
                _dbContext.MaintenanceIssueCategories.Remove(maintenanceIssueCategory);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
