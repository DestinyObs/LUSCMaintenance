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
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Reflection;

namespace LUSCMaintenance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LUSCMaintenanceDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IDataProtectionProvider _provider;
        private readonly ILogger<UserController> _logger;
        private readonly SmtpSettings _smtpSettings;

        public UserController(
            LUSCMaintenanceDbContext dbContext,
            IUserRepository userRepository, 
            IConfiguration configuration,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptions<SmtpSettings> smtpSettings,
            IDataProtectionProvider provider,
            ILogger<UserController> logger)

        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _provider = provider;
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
                    // Return validation errors with a 400 Bad Request status code
                    return BadRequest(new { Errors = validationResults.Select(vr => vr.ErrorMessage) });
                }

                // Check if the user already exists
                var existingUser = await _userRepository.GetUserByEmailAsync(request.WebMail);
                if (existingUser != null)
                {
                    // Return a conflict message with a 409 Conflict status code
                    return Conflict(new { Message = "User already exists." });
                }

                // Hash the user's password using BCrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

                // Create a new user
                var newUser = new User
                {
                    WebMail = request.WebMail,
                    UserName = request.WebMail,
                    IsVerified = false
                };

                // Save the user to the database
                var result = await _userManager.CreateAsync(newUser, request.Password);

                if (!result.Succeeded)
                {
                    // Return errors with a 400 Bad Request status code
                    return BadRequest(new { Errors = result.Errors.Select(error => error.Description) });
                }

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
                await SendVerificationEmail(newUser.WebMail, "Account Verification", GetVerificationEmailHtmlBody(newUser.Id.ToString(), verificationToken));

                // Return a success message with a 201 Created status code
                return CreatedAtAction(nameof(Register), new { StatusCode = 201, Message = "Registration successful. Check your email for verification." });


            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the registration request.");
                // Return a generic error message with a 500 Internal Server Error status code
                return StatusCode(StatusCodes.Status500InternalServerError, new { StatusCode = 500, Message = "An error occurred while processing the request." });
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Get the user making the request
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return NotFound(new { StatusCode = 404, Message = "User not found" });
                }

                // Perform logout logic by clearing authentication cookies
                await _signInManager.SignOutAsync();

                return Ok(new { StatusCode = 200, Message = "Logout successful" });
            }
            catch (Exception ex)
            {
                // Log the exception
                // You might want to log the exception details for troubleshooting
                _logger.LogError(ex, "An error occurred while processing the logout request.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { StatusCode = 500, Message = "An error occurred while processing the request." });
            }
        }



        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailRequest request)
        {
            try
            {
                var userVerification = await _userRepository.GetUserVerificationAsync(request.UserId, request.VerificationToken);

                if (userVerification == null)
                {
                    return NotFound(new { Message = "Invalid verification token or user not found." });
                }

                if (userVerification.IsVerified)
                {
                    return StatusCode(409, new { Message = "User already verified." }); // 409 Conflict could be used here
                }

                var expirationTime = DateTime.UtcNow.AddMinutes(-10);

                if (userVerification.CreatedAt < expirationTime)
                {
                    return StatusCode(410, new { Message = "Verification token has expired. Please request a new one." }); // 410 Gone indicates that the resource is no longer available
                }
                var userId = Convert.ToInt32(userVerification.UserId);
                // Retrieve the user based on the UserId from UserVerification
                var user = await _userRepository.GetUserByIdAsync(userId);


                if (user == null)
                {
                    return BadRequest("User not found.");
                }

                // Update the IsVerified property of the user
                user.IsVerified = true;

                // Save changes to the database
                await _userRepository.UpdateUserAsync(user);

                // Mark the verification token as used and delete it
                userVerification.IsVerified = true;
                await _userRepository.UpdateUserVerificationAsync(userVerification);


                return Ok(new { StatusCode = 200, Message = "Email verification successful. You can now log in." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the email verification request.");
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Exception = ex.Message });
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
                    // Return validation errors with a 400 Bad Request status code
                    return BadRequest(new { Errors = validationResults.Select(vr => vr.ErrorMessage) });
                }

                // Find the user by email
                var user = await _userRepository.GetUserByEmailAsync(request.WebMail);

                if (user == null)
                {
                    // Return a not found message with a 404 Not Found status code
                    return NotFound(new { Message = "User not found. Please check your email and password." });
                }

                // Verify the password
                if (!await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    // Return an unauthorized message with a 401 Unauthorized status code
                    return Unauthorized(new { Message = "Invalid credentials. Please check your email and password." });
                }

                    // Check if the user is verified
                    if (!user.IsVerified)
                {
                    // Generate a verification token
                    var verificationToken = GenerateVerificationToken();

                    // Create a UserVerification record
                    var userVerification = new UserVerification
                    {
                        UserId = user.Id.ToString(),
                        VerificationToken = verificationToken,
                        IsVerified = false,
                        CreatedAt = DateTime.UtcNow
                    };

                    // Save the UserVerification to the database
                    await _userRepository.CreateUserVerificationAsync(userVerification);

                    // Send verification email
                    await SendEmail(user.WebMail, "Account Verification", GetVerificationEmailBody(user.Id.ToString(), verificationToken));

                    // Return a forbidden message with a 403 Forbidden status code
                    return StatusCode(403, new { Message = "Email verification pending. Check your email for verification." });
                }

                // For simplicity, you can create a token and return it to the client
                var token = GenerateJwtToken(user);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            // Add any claims you need for the user here
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.WebMail),
            new Claim(ClaimTypes.Email, user.WebMail),

            // Add more claims as needed
        }, CookieAuthenticationDefaults.AuthenticationScheme)));

                // Return a success message with a 200 OK status code
                return Ok(new { Token = token, Email = user.WebMail });
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the login request.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing the request." });
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
                    // Return validation errors with a 400 Bad Request status code
                    return BadRequest(new { Errors = validationResults.Select(vr => vr.ErrorMessage) });
                }

                // Find the user by email
                var user = await _userRepository.GetUserByEmailAsync(request.WebMail);

                if (user == null)
                {
                    // Return a not found message with a 404 Not Found status code
                    return NotFound(new { Message = "User not found." });
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

                // Return a success message with a 200 OK status code
                return Ok(new { Message = "Password reset instructions sent to your email." });
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the forgot password request.");
                // Return a generic error message with a 500 Internal Server Error status code
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing the request." });
            }
        }
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] PasswordUpdateRequest request)
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

                // Validate the reset token
                var passwordReset = await _userRepository.GetPasswordResetByTokenAsync(request.ResetToken);

                if (passwordReset == null || passwordReset.IsUsed)
                {
                    return BadRequest("Invalid or expired reset token.");
                }

                // Find the user by Id
                var user = await _userRepository.GetUserByIdAsync(passwordReset.UserId);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                // Use UserManager to update the password
                var result = await _userManager.ResetPasswordAsync(user, request.ResetToken, request.NewPassword);

                if (!result.Succeeded)
                {
                    // Handle errors (e.g., invalid token, weak password)
                    return BadRequest(result.Errors.Select(error => error.Description));
                }

                // Mark the reset token as used and delete it
                passwordReset.IsUsed = true;
                await _userRepository.UpdatePasswordResetAsync(passwordReset);
                await _userRepository.DeletePasswordResetByTokenAsync(request.ResetToken);

                // No need to save the user separately when using UserManager
                return Ok(new { StatusCode = 200, Message = "Password updated successfully." });
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the password update request.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { StatusCode = 500, Message = "An error occurred while processing the request." });
            }
        }


        private string GeneratePasswordResetToken()
        {
            return Guid.NewGuid().ToString();
        }

        private async Task SendPasswordResetEmail(string email, string resetToken)
        {
            // Construct email body with reset link
            var resetLink = $"http://hostelmaintenance.lmu.edu.ng/forgetPassword?token={resetToken}";

            var body = $"Click the following link to reset your password: {resetLink} \n Note that the code expires after 10 minutes ";

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
                new Claim(ClaimTypes.Name, user.WebMail),
                new Claim(ClaimTypes.Email, user.WebMail),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(10), 
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
            //// Encrypt user ID and verification token
            //var encryptedUserId = ProtectData(userId);

            // Construct email body with encrypted verification link
            var verificationLink = $"http://hostelmaintenance.lmu.edu.ng/verify-email?userId={userId}&token={verificationToken}";
            return $"Click the following link to verify your email: {verificationLink}";
        }

        private string GetVerificationEmailHtmlBody(string userId, string verificationToken)
        {
            var verificationLink = $"http://hostelmaintenance.lmu.edu.ng/verify-email?userId={userId}&token={verificationToken}";
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "LUSCMaintenance.Helpers.SendVerifyEmail.html";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string htmlTemplate = reader.ReadToEnd();
                string htmlBody = htmlTemplate.Replace("YOUR_VERIFICATION_LINK", verificationLink);
                return htmlBody;
            }
        }




        // Encrypt data using IDataProtector
        private string ProtectData(string data)
        {
            // Convert data to bytes
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            // Create a data protector with a purpose string
            IDataProtector protector = _provider.CreateProtector("LUSCMaintenance.UserController.EmailVerification");

            // Encrypt the data
            byte[] encryptedBytes = protector.Protect(bytes);

            // Convert encrypted bytes back to string
            return Convert.ToBase64String(encryptedBytes);
        }


        // Decrypt data using IDataProtector
        private string UnprotectData(string encryptedData)
        {
            // Convert encrypted string to bytes
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

            // Create a data protector with the same purpose string
            IDataProtector protector = _provider.CreateProtector("LUSCMaintenance.UserController.EmailVerification");

            // Decrypt the data
            byte[] decryptedBytes = protector.Unprotect(encryptedBytes);

            // Convert decrypted bytes back to original data
            return Encoding.UTF8.GetString(decryptedBytes);
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

        private async Task SendVerificationEmail(string email, string subject, string htmlBody)
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
                mail.IsBodyHtml = true; // Set to true to indicate the body is HTML
                mail.Body = htmlBody; // Use the HTML body

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
