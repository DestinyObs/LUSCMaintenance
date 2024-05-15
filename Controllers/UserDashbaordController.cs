using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using System.Security.Claims;

namespace LUSCMaintenance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] // Requires authorization for all endpoints
    public class UserDashboardController : ControllerBase
    {
        private readonly IUserDashboardRepository _userDashboardRepository;

        public UserDashboardController(IUserDashboardRepository userDashboardRepository)
        {
            _userDashboardRepository = userDashboardRepository;
        }


        // GET: api/UserDashboard/issues
        [HttpGet("issues")]
        public async Task<IActionResult> GetIssuesByUserId()
        {
            try
            {
                // Get the current user's webmail from the claims
                var webmail = User.FindFirst(ClaimTypes.Email)?.Value;

                if (string.IsNullOrEmpty(webmail))
                {
                    return Unauthorized(new { Message = "Webmail claim not found in token." });
                }

                var issues = await _userDashboardRepository.GetIssuesByUserIdAsync(webmail);

                return Ok(issues);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing the request." });
            }
        }

        // GET: api/UserDashboard/issues/{issueId}
        [HttpGet("issues/{issueId}")]
        public async Task<IActionResult> GetIssueById(int issueId)
        {
            try
            {
                var issue = await _userDashboardRepository.GetIssueByIdAsync(issueId);
                if (issue == null)
                {
                    return NotFound(new { Message = "Issue not found." });
                }

                var webmail = User.FindFirst(ClaimTypes.Email)?.Value;
                if (issue.WebMail != webmail)
                {
                    return Forbid(); // Issue does not belong to the authenticated user
                }

                return Ok(issue);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing the request." });
            }
        }

        // POST: api/UserDashboard/issues/{issueId}/toggle-resolved
        [HttpPost("issues/{issueId}/toggle-resolved")]
        public async Task<IActionResult> ToggleIssueResolved(int issueId)
        {
            try
            {
                var issue = await _userDashboardRepository.GetIssueByIdAsync(issueId);
                if (issue == null)
                {
                    return NotFound(new { Message = "Issue not found." });
                }

                var webmail = User.FindFirst(ClaimTypes.Email)?.Value;
                if (issue.WebMail != webmail)
                {
                    return Forbid(); // Issue does not belong to the authenticated user
                }

                var result = await _userDashboardRepository.ToggleIssueResolvedAsync(issueId);
                if (!result)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while toggling the resolved status." });
                }

                return Ok(new { Message = "Issue resolved status toggled successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing the request." });
            }
        }

        // DELETE: api/UserDashboard/issues/{issueId}
        [HttpDelete("issues/{issueId}")]
        public async Task<IActionResult> DeleteIssue(int issueId)
        {
            try
            {
                var issue = await _userDashboardRepository.GetIssueByIdAsync(issueId);
                if (issue == null)
                {
                    return NotFound(new { Message = "Issue not found." });
                }

                var webmail = User.FindFirst(ClaimTypes.Email)?.Value;
                if (issue.WebMail != webmail)
                {
                    return Forbid(); // Issue does not belong to the authenticated user
                }

                var result = await _userDashboardRepository.DeleteIssueAsync(issueId);
                if (!result)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while deleting the issue." });
                }

                return Ok(new { Message = "Issue deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing the request." });
            }
        }

        // GET: api/UserDashboard/issues/filter-by-date
        [HttpGet("issues/filter-by-date")]
        public async Task<IActionResult> FilterIssuesByDate([FromQuery] DateTime date)
        {
            try
            {
                var webmail = User.FindFirst(ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(webmail))
                {
                    return Unauthorized(new { Message = "Webmail claim not found in token." });
                }

                var filteredIssues = await _userDashboardRepository.FilterIssuesByDateAsync(date);

                var userFilteredIssues = filteredIssues.Where(p => p.WebMail == webmail).ToList();

                return Ok(userFilteredIssues);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing the request." });
            }
        }

        // GET: api/UserDashboard/issues/filter-by-type
        [HttpGet("issues/filter-by-type")]
        public async Task<IActionResult> FilterIssuesByType([FromQuery] string issueCategory)
        {
            try
            {
                var webmail = User.FindFirst(ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(webmail))
                {
                    return Unauthorized(new { Message = "Webmail claim not found in token." });
                }

                var filteredIssues = await _userDashboardRepository.FilterIssuesByTypeAsync(issueCategory);

                var userFilteredIssues = filteredIssues.Where(p => p.WebMail == webmail).ToList();

                return Ok(userFilteredIssues);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing the request." });
            }
        }

        // GET: api/UserDashboard/issues/filter-by-status
        [HttpGet("issues/filter-by-status")]
        public async Task<IActionResult> FilterIssuesByStatus([FromQuery] bool isResolved)
        {
            try
            {
                // Get the current user's webmail from the token
                var webmail = User.Identity.Name;

                var filteredIssues = await _userDashboardRepository.FilterIssuesByStatusAsync(isResolved);

                // Filter the issues based on the current user's webmail
                var userFilteredIssues = filteredIssues.Where(p => p.WebMail == webmail).ToList();

                return Ok(userFilteredIssues);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing the request." });
            }
        }

    }
}
