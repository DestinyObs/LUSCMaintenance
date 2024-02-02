

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
using LUSCMaintenance.Services;
using LUSCMaintenance.Repositories;

namespace LUSCMaintenance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceProblemController : ControllerBase
    {
        private readonly IMaintenanceProblemRepository _maintenanceProblemRepository;
        private readonly IPhotoService _photoService;
        private readonly IMaintenanceIssueRepository _maintenanceIssueRepository;

        public MaintenanceProblemController(IMaintenanceProblemRepository maintenanceProblemRepository, IPhotoService photoService, IMaintenanceIssueRepository maintenanceIssueRepository)
        {
            _maintenanceProblemRepository = maintenanceProblemRepository;
            _photoService = photoService;
            _maintenanceIssueRepository = maintenanceIssueRepository;
        }

        [HttpPost]
        public async Task<ActionResult<MaintenanceProblemResponse>> AddMaintenanceProblem([FromForm] MaintenanceProblemRequest maintenanceProblemRequest)
        {
            if (maintenanceProblemRequest == null)
            {
                return BadRequest("Invalid request data.");
            }

            // Extract user's webmail from claims
            var userWebMail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userWebMail))
            {
                return BadRequest("Unable to identify user.");
            }

            // Initialize imageURL to null
            string imageUrl = null;

            // Check if an image was provided in the request
            if (maintenanceProblemRequest.Image != null && maintenanceProblemRequest.Image.Length > 0)
            {
                // Use the PhotoService to upload the image to Cloudinary
                var uploadResult = await _photoService.AddPhotoAsync(maintenanceProblemRequest.Image);

                // Check if image upload was successful
                if (uploadResult.Error == null)
                {
                    imageUrl = uploadResult.SecureUri.AbsoluteUri;
                }
                else
                {
                    // Handle image upload failure
                    return BadRequest("Failed to upload photo.");
                }
            }

            // Map DTO to entity
            var maintenanceProblem = new MaintenanceProblem
            {
                WebMail = userWebMail,
                Block = maintenanceProblemRequest.Block,
                Hostel = maintenanceProblemRequest.Hostel,
                RoomNumber = maintenanceProblemRequest.RoomNumber,
                TimeAvailable = maintenanceProblemRequest.TimeAvailable,
                ImageURL = imageUrl,
                DateComplaintMade = DateTime.UtcNow,
                IsResolved = false
            };

            // Get maintenance issues by IDs
            var maintenanceIssues = await _maintenanceIssueRepository.GetMaintenanceIssuesAsync();
            var selectedIssues = maintenanceIssues.Where(issue => maintenanceProblemRequest.MaintenanceIssueIds.Contains(issue.Id)).ToList();
            if (selectedIssues.Count != maintenanceProblemRequest.MaintenanceIssueIds.Count)
            {
                return BadRequest("One or more selected issues are invalid.");
            }

            // Add selected issues to the maintenance problem
            maintenanceProblem.MaintenanceProblemIssues = selectedIssues.Select(issue => new MaintenanceProblemIssue
            {
                MaintenanceIssueId = issue.Id,
                MaintenanceIssue = issue,
                MaintenanceProblem = maintenanceProblem
            }).ToList();

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
                MaintenanceIssueIds = maintenanceProblem.MaintenanceProblemIssues.Select(issue => issue.MaintenanceIssueId).ToList()
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
                ImageUrl = maintenanceProblem.ImageURL,
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

        [HttpGet("userProblems")]
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
                ImageUrl = problem.ImageURL,
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