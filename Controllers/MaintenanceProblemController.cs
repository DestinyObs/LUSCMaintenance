// MaintenanceProblemController.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using LUSCMaintenance.Services;
using LUSCMaintenance.Controllers;
using System.Security.Claims;

namespace LUSC_e_Maintenance.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceProblemController : ControllerBase
    {
        private readonly IMaintenanceProblemRepository _maintenanceProblemRepository;
        private readonly IPhotoService _photoService;

        public MaintenanceProblemController(
            IMaintenanceProblemRepository maintenanceProblemRepository,
            IPhotoService photoService)
        {
            _maintenanceProblemRepository = maintenanceProblemRepository;
            _photoService = photoService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceProblemResponse>>> GetMaintenanceProblems()
        {
            var maintenanceProblems = await _maintenanceProblemRepository.GetMaintenanceProblemsAsync();
            var response = MapToResponse(maintenanceProblems);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceProblemResponse>> GetMaintenanceProblemById(int id)
        {
            var maintenanceProblem = await _maintenanceProblemRepository.GetMaintenanceProblemByIdAsync(id);
            if (maintenanceProblem == null)
            {
                return NotFound();
            }

            var response = MapToResponse(maintenanceProblem);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenanceProblem(int id, [FromBody] MaintenanceProblemResponse maintenanceProblem)
        {
            if (id != maintenanceProblem.Id)
            {
                return BadRequest();
            }

            var problemToUpdate = await _maintenanceProblemRepository.GetMaintenanceProblemByIdAsync(id);
            if (problemToUpdate == null)
            {
                return NotFound();
            }

            MapToEntity(maintenanceProblem, problemToUpdate);

            await _maintenanceProblemRepository.UpdateMaintenanceProblemAsync(problemToUpdate);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceProblem(int id)
        {
            await _maintenanceProblemRepository.DeleteMaintenanceProblemAsync(id);
            return NoContent();
        }

        [Authorize(Roles = "Student")]
        [HttpPost]
        public async Task<ActionResult<MaintenanceProblemResponse>> AddMaintenanceProblem([FromBody] MaintenanceProblemRequest maintenanceProblemRequest)
        {
            var userWebMail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            if (maintenanceProblemRequest.Image != null && maintenanceProblemRequest.Image.Length > 0)
            {
                var uploadResult = await _photoService.AddPhotoAsync(maintenanceProblemRequest.Image);

                if (uploadResult.Error == null)
                {
                    maintenanceProblemRequest.ImageURL = uploadResult.SecureUri.AbsoluteUri;
                }
                else
                {
                    return BadRequest("Failed to upload photo.");
                }
            }

            var maintenanceProblem = new MaintenanceProblem
            {
                WebMail = userWebMail,
                ImageURL = maintenanceProblemRequest.ImageURL,
                MaintenanceIssueId = maintenanceProblemRequest.MaintenanceIssueCategoryId,
                Block = maintenanceProblemRequest.Block,
                Hostel = maintenanceProblemRequest.Hostel,
                RoomNumber = maintenanceProblemRequest.RoomNumber,
                TimeAvailable = maintenanceProblemRequest.TimeAvailable,
                DateComplaintMade = DateTime.Now,
                IsResolved = false
            };

            await _maintenanceProblemRepository.AddMaintenanceProblemAsync(maintenanceProblem);

            var response = MapToResponse(maintenanceProblem);
            return CreatedAtAction(nameof(GetMaintenanceProblemById), new { id = maintenanceProblem.Id }, response);
        }

        private List<MaintenanceProblemResponse> MapToResponse(IEnumerable<MaintenanceProblem> problems)
        {
            return problems.Select(problem => new MaintenanceProblemResponse
            {
                Id = problem.Id,
                WebMail = problem.WebMail,
                ImageURL = problem.ImageURL,
                MaintenanceIssueId = problem.MaintenanceIssueId,
                Block = problem.Block,
                Hostel = problem.Hostel,
                RoomNumber = problem.RoomNumber,
                TimeAvailable = problem.TimeAvailable,
                DateComplaintMade = problem.DateComplaintMade,
                IsResolved = problem.IsResolved
            }).ToList();
        }

        private MaintenanceProblemResponse MapToResponse(MaintenanceProblem problem)
        {
            return new MaintenanceProblemResponse
            {
                Id = problem.Id,
                WebMail = problem.WebMail,
                ImageURL = problem.ImageURL,
                MaintenanceIssueId = problem.MaintenanceIssueId,
                Block = problem.Block,
                Hostel = problem.Hostel,
                RoomNumber = problem.RoomNumber,
                TimeAvailable = problem.TimeAvailable,
                DateComplaintMade = problem.DateComplaintMade,
                IsResolved = problem.IsResolved
            };
        }

        private void MapToEntity(MaintenanceProblemResponse response, MaintenanceProblem problem)
        {
            problem.WebMail = response.WebMail;
            problem.ImageURL = response.ImageURL;
            problem.MaintenanceIssueId = response.MaintenanceIssueId;
            problem.Block = response.Block;
            problem.Hostel = response.Hostel;
            problem.RoomNumber = response.RoomNumber;
            problem.TimeAvailable = response.TimeAvailable;
            problem.DateComplaintMade = response.DateComplaintMade;
            problem.IsResolved = response.IsResolved;
        }
    }
}
