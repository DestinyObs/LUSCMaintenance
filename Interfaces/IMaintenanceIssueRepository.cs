using LUSCMaintenance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LUSCMaintenance.Interfaces
{
    public interface IMaintenanceIssueRepository
    {
        Task<IEnumerable<MaintenanceIssue>> GetMaintenanceIssuesAsync();
        Task<MaintenanceIssue> GetMaintenanceIssueByIdAsync(int id);
        Task AddMaintenanceIssueAsync(MaintenanceIssue maintenanceIssue);
        Task<IEnumerable<MaintenanceIssue>> GetMaintenanceIssuesByCategoryAsync(int categoryId);

        Task UpdateMaintenanceIssueAsync(MaintenanceIssue maintenanceIssue);
        Task DeleteMaintenanceIssueAsync(int id);
    }
}
