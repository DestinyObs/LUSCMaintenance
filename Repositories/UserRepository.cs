using LUSCMaintenance.Data;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LUSCMaintenance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LUSCMaintenanceDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public UserRepository(LUSCMaintenanceDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }



        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }


        public async Task<User> GetUserByEmailAsync(string webMail)
        {
            return await _dbContext.Users
                .Include(u => u.UserVerification)
                .FirstOrDefaultAsync(u => u.WebMail == webMail);
        }
        public async Task CreatePasswordResetAsync(PasswordReset passwordReset)
        {
            _dbContext.PasswordResets.Add(passwordReset);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            // Ensure the user with the same email does not already exist
            if (await GetUserByEmailAsync(user.WebMail) != null)
            {
                throw new InvalidOperationException("User with the same email already exists.");
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserVerification> GetUserVerificationAsync(string userId, string token)
        {
            var expirationTime = DateTime.UtcNow.AddMinutes(-10);

            var userVerification = await _dbContext.UserVerifications
                .FirstOrDefaultAsync(uv => uv.UserId == userId && uv.VerificationToken == token && !uv.IsVerified && uv.CreatedAt > expirationTime);

            return userVerification;
        }


        public async Task CreateUserVerificationAsync(UserVerification userVerification)
        {
            _dbContext.UserVerifications.Add(userVerification);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserVerificationAsync(UserVerification userVerification)
        {
            _dbContext.Entry(userVerification).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdatePasswordResetAsync(PasswordReset passwordReset)
        {

            // Mark the entity as modified
            _dbContext.Entry(passwordReset).State = EntityState.Modified;

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateUser(User user)
        {
            await _userManager.UpdateAsync(user);
        }
        public async Task<PasswordReset> GetPasswordResetByTokenAsync(string resetToken)
        {
            return await _dbContext.PasswordResets.FirstOrDefaultAsync(pr => pr.ResetToken == resetToken);
        }

        public async Task DeletePasswordResetByTokenAsync(string resetToken)
        {
            var passwordReset = await _dbContext.PasswordResets.FirstOrDefaultAsync(pr => pr.ResetToken == resetToken);
            if (passwordReset != null)
            {
                _dbContext.PasswordResets.Remove(passwordReset);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
