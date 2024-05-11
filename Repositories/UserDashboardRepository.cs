using LUSCMaintenance.Data;
using LUSCMaintenance.Models;
using Microsoft.AspNetCore.Identity;

namespace LUSCMaintenance.Repositories
{
    public class UserDashboardRepository
    {
        private readonly LUSCMaintenanceDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public UserDashboardRepository (LUSCMaintenanceDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }


    }
}
