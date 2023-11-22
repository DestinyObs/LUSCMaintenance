using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using LUSCMaintenance.Data;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using LUSCMaintenance.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LUSCMaintenance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LUSCMaintenanceDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserController> _logger;
        private readonly SmtpSettings _smtpSettings;

        public UserController(
            LUSCMaintenanceDbContext dbContext,
            IUserRepository userRepository, 
            IConfiguration configuration,
            IOptions<SmtpSettings> smtpSettings,
            ILogger<UserController> logger)

        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _configuration = configuration;
            _logger = logger;
            _smtpSettings = smtpSettings.Value;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserLoginRequest request)
        {
            try
            {
                // Validate the request using the view model
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(request, validationContext, validationResults, validateAllProperties: true))
                {
                    // Return validation errors
                    return BadRequest(validationResults.Select(vr => vr.ErrorMessage));
                }

                // Check if the user already exists
                var existingUser = await _userRepository.GetUserByEmailAsync(request.WebMail);
                if (existingUser != null)
                {
                    return Conflict("User already exists.");
                }

                // Hash the user's password using BCrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

                // Create a new user
                var newUser = new User
                {
                    WebMail = request.WebMail,
                    Password = hashedPassword,
                    IsVerified = false
                };

                // Save the user to the database
                await _userRepository.CreateUserAsync(newUser);

                // Generate a verification token
                var verificationToken = GenerateVerificationToken();

                // Create a UserVerification record
                var userVerification = new UserVerification
                {
                    UserId = newUser.Id.ToString(),
                    VerificationToken = verificationToken,
                    IsVerified = false,
                    CreatedAt = DateTime.UtcNow
                };

                // Save the UserVerification to the database
                await _userRepository.CreateUserVerificationAsync(userVerification);

                // Send verification email
                await SendEmail(newUser.WebMail, "Account Verification", GetVerificationEmailBody(newUser.Id.ToString(), verificationToken));

                // Return a success message
                return Ok("Registration successful. Check your email for verification.");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the registration request.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                // Validate the request using the view model
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(request, validationContext, validationResults, validateAllProperties: true))
                {
                    // Return validation errors
                    return BadRequest(validationResults.Select(vr => vr.ErrorMessage));
                }

                // Find the user by email
                var user = await _userRepository.GetUserByEmailAsync(request.WebMail);

                if (user == null)
                {
                    return NotFound("User not found. Please check your email and password.");
                }

                // Verify the password
                if (BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                {
                    // Check if the user is verified
                    if (!user.IsVerified)
                    {
                        return BadRequest("User email is not verified. Please check your email for verification instructions.");
                    }

                    // For simplicity, you can create a token and return it to the client
                    var token = GenerateJwtToken(user);

                    return Ok(new { Token = token });
                }

                return Unauthorized("Invalid credentials. Please check your email and password.");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the login request.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            try
            {
                // Validate the request using the view model
                var validationContext = new ValidationContext(request, serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(request, validationContext, validationResults, validateAllProperties: true))
                {
                    // Return validation errors
                    return BadRequest(validationResults.Select(vr => vr.ErrorMessage));
                }

                // Find the user by email
                var user = await _userRepository.GetUserByEmailAsync(request.WebMail);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                // Generate a password reset token
                var resetToken = GeneratePasswordResetToken();

                // Create a PasswordReset record
                var passwordReset = new PasswordReset
                {
                    UserId = user.Id,
                    ResetToken = resetToken,
                    IsUsed = false,
                    CreatedAt = DateTime.UtcNow
                };

                // Save the PasswordReset to the database
                await _userRepository.CreatePasswordResetAsync(passwordReset);

                // Send the password reset email
                await SendPasswordResetEmail(user.WebMail, resetToken);

                // Return a success message
                return Ok("Password reset instructions sent to your email.");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the forgot password request.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

        private string GeneratePasswordResetToken()
        {
            return Guid.NewGuid().ToString();
        }

        private async Task SendPasswordResetEmail(string email, string resetToken)
        {
            // Construct email body with reset link
            var resetLink = $"https://localhost:3000/reset-password?token={resetToken}";
            var body = $"Click the following link to reset your password: {resetLink}";

            // Send the email (you can use your existing email sending logic)
            await SendEmail(email, "Password Reset", body);
        }


        // Your JWT token generation logic goes here
        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Email, user.WebMail),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    };
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(10), // Token expiration time (adjust as needed)
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }


        private string GenerateVerificationToken()
        {
            return Guid.NewGuid().ToString();
        }

        private string GetVerificationEmailBody(string userId, string verificationToken)
        {
            // Encrypt user ID and verification token
            var encryptedUserId = ProtectData(userId);

            // Construct email body with encrypted verification link
            var verificationLink = $"https://localhost:3000/verify-email?userId={encryptedUserId}&token={verificationToken}";
            return $"Click the following link to verify your email: {verificationLink}";
        }

        // Encrypt data using ProtectedData
        private string ProtectData(string data)
        {
            // Convert data to bytes
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            // Encrypt the data
            byte[] encryptedBytes = ProtectedData.Protect(bytes, optionalEntropy: null, scope: DataProtectionScope.CurrentUser);

            // Convert encrypted bytes back to string
            return Convert.ToBase64String(encryptedBytes);
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
