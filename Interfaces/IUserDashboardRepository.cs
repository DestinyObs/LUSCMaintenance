using LUSCMaintenance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LUSCMaintenance.Interfaces
{
    public interface IUserDashboardRepository
    {

        Task<List<MaintenanceProblem>> GetIssuesByUserIdAsync(string webmail);
        Task<MaintenanceProblem> GetIssueByIdAsync(int issueId);
        Task<bool> DeleteIssueAsync(int issueId);
        Task<List<MaintenanceProblem>> FilterIssuesByDateAsync(DateTime date);
        Task<List<MaintenanceProblem>> FilterIssuesByTypeAsync(string issueType);
        Task<bool> ToggleIssueResolvedAsync(int issueId);
        Task<List<MaintenanceProblem>> FilterIssuesByStatusAsync(bool isResolved);
    }
}
