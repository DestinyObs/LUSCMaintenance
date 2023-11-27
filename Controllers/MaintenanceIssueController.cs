using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LUSCMaintenance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceIssueController : ControllerBase
    {
        private readonly IMaintenanceIssueRepository _maintenanceIssueRepository;

        public MaintenanceIssueController(IMaintenanceIssueRepository maintenanceIssueRepository)
        {
            _maintenanceIssueRepository = maintenanceIssueRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceIssue>>> GetMaintenanceIssues()
        {
            var issues = await _maintenanceIssueRepository.GetMaintenanceIssuesAsync();
            return Ok(issues);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<MaintenanceIssue>>> GetMaintenanceIssuesByCategory(int categoryId)
        {
            var issues = await _maintenanceIssueRepository.GetMaintenanceIssuesByCategoryAsync(categoryId);
            return Ok(issues);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceIssue>> GetMaintenanceIssueById(int id)
        {
            var issue = await _maintenanceIssueRepository.GetMaintenanceIssueByIdAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            return Ok(issue);
        }

        [HttpPost]
        public async Task<ActionResult<MaintenanceIssue>> AddMaintenanceIssue([FromBody] MaintenanceIssue maintenanceIssue)
        {
            await _maintenanceIssueRepository.AddMaintenanceIssueAsync(maintenanceIssue);
            return CreatedAtAction(nameof(GetMaintenanceIssueById), new { id = maintenanceIssue.Id }, maintenanceIssue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenanceIssue(int id, [FromBody] MaintenanceIssue maintenanceIssue)
        {
            if (id != maintenanceIssue.Id)
            {
                return BadRequest();
            }

            await _maintenanceIssueRepository.UpdateMaintenanceIssueAsync(maintenanceIssue);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceIssue(int id)
        {
            await _maintenanceIssueRepository.DeleteMaintenanceIssueAsync(id);
            return NoContent();
        }
    }
}
