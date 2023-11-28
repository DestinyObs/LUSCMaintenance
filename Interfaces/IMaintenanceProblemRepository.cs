using LUSCMaintenance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LUSCMaintenance.Interfaces
{
    public interface IMaintenanceProblemRepository
    {
        Task<IEnumerable<MaintenanceProblem>> GetMaintenanceProblemsAsync();
        Task<MaintenanceProblem> GetMaintenanceProblemByIdAsync(int id);
        Task AddMaintenanceProblemAsync(MaintenanceProblem maintenanceProblem);
        Task UpdateMaintenanceProblemAsync(MaintenanceProblem maintenanceProblem);
        Task DeleteMaintenanceProblemAsync(int id);
    }
}
