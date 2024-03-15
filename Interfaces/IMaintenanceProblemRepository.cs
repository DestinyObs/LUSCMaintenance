using System.Collections.Generic;
using System.Threading.Tasks;
using LUSCMaintenance.Models;

namespace LUSCMaintenance.Interfaces
{
    public interface IMaintenanceProblemRepository
    {
        Task<IEnumerable<MaintenanceProblem>> GetMaintenanceProblemsAsync();
        Task<MaintenanceProblem> GetMaintenanceProblemByIdAsync(int id);
        Task<MaintenanceProblem> AddMaintenanceProblemAsync(MaintenanceProblem maintenanceProblem);
        Task UpdateMaintenanceProblemAsync(MaintenanceProblem maintenanceProblem);
        Task<List<MaintenanceProblem>> GetAllMaintenanceProblemsWithRelatedDataAsync();
        Task DeleteMaintenanceProblemAsync(int id);
        Task<IEnumerable<MaintenanceProblem>> GetMaintenanceProblemsByUserAsync(string userWebMail);

    }
}
