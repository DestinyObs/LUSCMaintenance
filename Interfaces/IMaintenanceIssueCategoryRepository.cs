using System.Collections.Generic;
using System.Threading.Tasks;
using LUSCMaintenance.Models;

namespace LUSCMaintenance.Interfaces
{
    public interface IMaintenanceIssueCategoryRepository
    {
        Task<IEnumerable<MaintenanceIssueCategory>> GetMaintenanceIssueCategoriesAsync();
        Task<MaintenanceIssueCategory> GetMaintenanceIssueCategoryByIdAsync(int id);
        Task AddMaintenanceIssueCategoryAsync(MaintenanceIssueCategory maintenanceIssueCategory);
        Task UpdateMaintenanceIssueCategoryAsync(MaintenanceIssueCategory maintenanceIssueCategory);
        Task DeleteMaintenanceIssueCategoryAsync(int id);
    }
}
