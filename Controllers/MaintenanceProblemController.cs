using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using LUSCMaintenance.DTOs;
using System.Security.Claims;
using LUSCMaintenance.ViewModels;

namespace LUSCMaintenance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceProblemController : ControllerBase
    {
        private readonly IMaintenanceProblemRepository _maintenanceProblemRepository;

        public MaintenanceProblemController(IMaintenanceProblemRepository maintenanceProblemRepository)
        {
            _maintenanceProblemRepository = maintenanceProblemRepository;
        }


        [HttpPost]
        public async Task<ActionResult<MaintenanceProblemResponse>> AddMaintenanceProblem([FromBody] MaintenanceProblemRequest maintenanceProblemRequest)
        {
            if (maintenanceProblemRequest == null)
            {
                return BadRequest("Invalid request data.");
            }

            // Extract user's webmail from claims
            var userWebMail = User.FindFirst(ClaimTypes.Email)?.Value;

            // Map DTO to entity
            var maintenanceProblem = new MaintenanceProblem
            {
                WebMail = userWebMail,
                Block = maintenanceProblemRequest.Block,
                Hostel = maintenanceProblemRequest.Hostel,
                RoomNumber = maintenanceProblemRequest.RoomNumber,
                TimeAvailable = maintenanceProblemRequest.TimeAvailable,
                DateComplaintMade = DateTime.UtcNow,
                IsResolved = false,
                MaintenanceProblemIssues = maintenanceProblemRequest.MaintenanceIssueIds.Select(id => new MaintenanceIssue { Id = id }).ToList()
            };

            // Add maintenance problem to repository
            await _maintenanceProblemRepository.AddMaintenanceProblemAsync(maintenanceProblem);

            // Map entity to response DTO
            var response = new MaintenanceProblemResponse
            {
                Id = maintenanceProblem.Id,
                WebMail = maintenanceProblem.WebMail,
                Block = maintenanceProblem.Block,
                Hostel = maintenanceProblem.Hostel,
                RoomNumber = maintenanceProblem.RoomNumber,
                TimeAvailable = maintenanceProblem.TimeAvailable,
                DateComplaintMade = maintenanceProblem.DateComplaintMade,
                IsResolved = maintenanceProblem.IsResolved,
                MaintenanceIssueIds = maintenanceProblem.MaintenanceProblemIssues.Select(issue => issue.Id).ToList()
            };

            return CreatedAtAction(nameof(GetMaintenanceProblemById), new { id = maintenanceProblem.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceProblemResponse>> GetMaintenanceProblemById(int id)
        {
            var maintenanceProblem = await _maintenanceProblemRepository.GetMaintenanceProblemByIdAsync(id);
            if (maintenanceProblem == null)
            {
                return NotFound();
            }

            var response = new MaintenanceProblemResponse
            {
                Id = maintenanceProblem.Id,
                WebMail = maintenanceProblem.WebMail,
                Block = maintenanceProblem.Block,
                Hostel = maintenanceProblem.Hostel,
                RoomNumber = maintenanceProblem.RoomNumber,
                TimeAvailable = maintenanceProblem.TimeAvailable,
                DateComplaintMade = maintenanceProblem.DateComplaintMade,
                IsResolved = maintenanceProblem.IsResolved,
                MaintenanceIssueIds = maintenanceProblem.MaintenanceProblemIssues.Select(issue => issue.Id).ToList()
            };

            return Ok(response);
        }

        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<MaintenanceProblemResponse>>> GetMaintenanceProblemsByCurrentUser()
        {
            var userWebMail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userWebMail == null)
            {
                return BadRequest("User not authenticated.");
            }

            var maintenanceProblems = await _maintenanceProblemRepository.GetMaintenanceProblemsByUserAsync(userWebMail);
            var response = maintenanceProblems.Select(problem => new MaintenanceProblemResponse
            {
                Id = problem.Id,
                WebMail = problem.WebMail,
                Block = problem.Block,
                Hostel = problem.Hostel,
                RoomNumber = problem.RoomNumber,
                TimeAvailable = problem.TimeAvailable,
                DateComplaintMade = problem.DateComplaintMade,
                IsResolved = problem.IsResolved,
                MaintenanceIssueIds = problem.MaintenanceProblemIssues.Select(issue => issue.Id).ToList()
            });

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenanceProblem(int id, [FromBody] MaintenanceProblemUpdateRequest maintenanceProblemUpdateRequest)
        {
            var maintenanceProblem = await _maintenanceProblemRepository.GetMaintenanceProblemByIdAsync(id);
            if (maintenanceProblem == null)
            {
                return NotFound();
            }

            maintenanceProblem.IsResolved = maintenanceProblemUpdateRequest.IsResolved;
            await _maintenanceProblemRepository.UpdateMaintenanceProblemAsync(maintenanceProblem);

            return NoContent();
        }
    }
}
