using LUSCMaintenance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LUSCMaintenance.Interfaces
{
    public interface IUserDashboardRepository
    {

        Task<List<MaintenanceProblem>> GetIssuesByUserIdAsync(string webmail);
        Task<MaintenanceProblem> GetIssueByIdAsync(int issueId);
        Task<bool> UpdateIssueAsync(int issueId, MaintenanceProblem updatedIssue);
        Task<bool> DeleteIssueAsync(int issueId);
        Task<List<MaintenanceProblem>> FilterIssuesByDateAsync(string date);
        Task<List<MaintenanceProblem>> FilterIssuesByTypeAsync(string issueType);
        Task<List<MaintenanceProblem>> FilterIssuesByStatusAsync(string status);
    }
}
