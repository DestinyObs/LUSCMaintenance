//using LUSCMaintenance.Data;
//using LUSCMaintenance.Interfaces;
//using LUSCMaintenance.Models;
//using Microsoft.EntityFrameworkCore;

//namespace LUSCMaintenance.Repositories
//{
//    public class AdminRepository : IAdminRepository
//    {

//        private readonly LUSCMaintenanceDbContext _dbContext;

//        public MaintenanceIssueCategoryRepository(LUSCMaintenanceDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<List<MaintenanceProblem>> GetTopFourCurrentMostOccurringProblemsAsync()
//        {

//            // Get the count of unresolved issues for each maintenance problem
//            var problemCounts = await _dbContext.MaintenanceProblems
//                .Where(p => !p.IsResolved)
//                .GroupBy(p => p.Id)
//                .Select(g => new { ProblemId = g.Key, Count = g.Count() })
//                .ToListAsync();

//            // Sort the problems by count in descending order and take the top 4
//            var topFourProblemIds = problemCounts
//                .OrderByDescending(pc => pc.Count)
//                .Take(4)
//                .Select(pc => pc.ProblemId);

//            // Retrieve the top 4 problems from the database
//            var topFourProblems = await _dbContext.MaintenanceProblems
//                .Include(p => p.MaintenanceProblemIssues)
//                .Where(p => topFourProblemIds.Contains(p.Id))
//                .ToListAsync();

//            return topFourProblems;
//        }

//    }
//}
