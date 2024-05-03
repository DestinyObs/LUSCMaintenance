using LUSCMaintenance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LUSCMaintenance.Interfaces
{
    public interface IAdminRepository
    {
        // Key Issues Section
        Task<List<KeyIssueCategory>> GetKeyIssueCategoriesAsync();
        Task<List<KeyIssueSummary>> GetKeyIssueSummariesAsync();
        Task<decimal> GetRateOfChangeAsync();

        // Search Functionality
        Task<List<SearchResult>> SearchAsync(string searchTerm);

        // Filters
        Task<List<MaintenanceIssue>> GetMaintenanceIssuesByFilterAsync(FilterCriteria criteria);

        // Detailed Issues Table
        Task<List<MaintenanceProblemDetail>> GetMaintenanceProblemsAsync();

        // Download Reports
        Task<byte[]> DownloadMaintenanceComplaintsReportAsync(DownloadOption option);

        // Notifications
        Task<List<Notification>> GetNotificationsAsync();

        // Admin Rights
        Task<int> AddMaintenanceIssueAsync(MaintenanceIssue maintenanceIssue);
        Task<int> UpdateMaintenanceIssueAsync(MaintenanceIssue maintenanceIssue);
        Task<int> DeleteMaintenanceIssueAsync(int issueId);

        Task<int> UpdateMaintenanceProblemStatusAsync(int problemId, bool isResolved);
        Task<int> DeleteMaintenanceProblemAsync(int problemId);
    }
}
