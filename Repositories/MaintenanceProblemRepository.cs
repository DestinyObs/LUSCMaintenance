﻿// MaintenanceProblemRepository.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LUSCMaintenance.Data;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using Microsoft.EntityFrameworkCore;

namespace LUSCMaintenance.Repositories
{
    public class MaintenanceProblemRepository : IMaintenanceProblemRepository
    {
        private readonly LUSCMaintenanceDbContext _context;

        public MaintenanceProblemRepository(LUSCMaintenanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceProblem>> GetMaintenanceProblemsAsync()
        {
            return await _context.MaintenanceProblems.ToListAsync();
        }

        public async Task<MaintenanceProblem> GetMaintenanceProblemByIdAsync(int id)
        {
            return await _context.MaintenanceProblems.FindAsync(id);
        }

        public async Task AddMaintenanceProblemAsync(MaintenanceProblem maintenanceProblem)
        {
            _context.MaintenanceProblems.Add(maintenanceProblem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMaintenanceProblemAsync(MaintenanceProblem maintenanceProblem)
        {
            _context.MaintenanceProblems.Update(maintenanceProblem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMaintenanceProblemAsync(int id)
        {
            var maintenanceProblem = await _context.MaintenanceProblems.FindAsync(id);
            if (maintenanceProblem != null)
            {
                _context.MaintenanceProblems.Remove(maintenanceProblem);
                await _context.SaveChangesAsync();
            }
        }
    }
}