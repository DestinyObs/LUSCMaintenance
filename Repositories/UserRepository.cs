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

        public UserRepository(LUSCMaintenanceDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task<UserVerification> GetUserVerificationAsync(string userId)
        {
            return await _dbContext.UserVerifications
                .FirstOrDefaultAsync(uv => uv.UserId == userId);
        }

        public async Task CreateUserVerificationAsync(UserVerification userVerification)
        {
            _dbContext.UserVerifications.Add(userVerification);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserVerificationAsync(UserVerification userVerification)
        {
            _dbContext.UserVerifications.Update(userVerification);
            await _dbContext.SaveChangesAsync();
        }
    }
}
