using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
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
        private readonly ILogger<UserController> _logger;
        private readonly SmtpSettings _smtpSettings;

        public MaintenanceProblemController(IMaintenanceProblemRepository maintenanceProblemRepository, IOptions<SmtpSettings> smtpSettings, ILogger<UserController> logger)
        {
            _maintenanceProblemRepository = maintenanceProblemRepository;
            _logger = logger;
            _smtpSettings = smtpSettings.Value;
        }

        [Authorize(Roles = "Student")]
        [HttpPost]
        public async Task<ActionResult<MaintenanceProblem>> AddMaintenanceProblem([FromBody] MaintenanceProblem maintenanceProblem)
        {
            // Extract webmail from the authorized JWT token
            var userWebMail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;


            // Populate the maintenance problem properties
            maintenanceProblem.WebMail = userWebMail;
            maintenanceProblem.TimeAvailable = DateTime.Now;

            // Add the maintenance problem
            await _maintenanceProblemRepository.AddMaintenanceProblemAsync(maintenanceProblem);

            // Send email notification to the user (you can use your existing SendEmail logic)
            await SendEmail(userWebMail, "Maintenance Problem Submitted", "Your maintenance problem has been submitted successfully.");

            return CreatedAtAction(nameof(GetMaintenanceProblemById), new { id = maintenanceProblem.Id }, maintenanceProblem);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceProblem>>> GetMaintenanceProblems()
        {
            var maintenanceProblems = await _maintenanceProblemRepository.GetMaintenanceProblemsAsync();
            return Ok(maintenanceProblems);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceProblem>> GetMaintenanceProblemById(int id)
        {
            var maintenanceProblem = await _maintenanceProblemRepository.GetMaintenanceProblemByIdAsync(id);
            if (maintenanceProblem == null)
            {
                return NotFound();
            }
            return Ok(maintenanceProblem);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenanceProblem(int id, [FromBody] MaintenanceProblem maintenanceProblem)
        {
            if (id != maintenanceProblem.Id)
            {
                return BadRequest();
            }

            await _maintenanceProblemRepository.UpdateMaintenanceProblemAsync(maintenanceProblem);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceProblem(int id)
        {
            await _maintenanceProblemRepository.DeleteMaintenanceProblemAsync(id);
            return NoContent();
        }

        private async Task SendEmail(string email, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                smtpClient.EnableSsl = true;

                mail.From = new MailAddress("info@LUSCe-maintenance");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;

                smtpClient.Send(mail);

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while sending the email.");
            }
        }
      
    }
}
