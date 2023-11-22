﻿using LUSCMaintenance.Models;

namespace LUSCMaintenance.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string webMail);
        Task<User> GetUserByIdAsync(int userId);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<UserVerification> GetUserVerificationAsync(string userId);
        Task CreatePasswordResetAsync(PasswordReset passwordReset);
        Task CreateUserVerificationAsync(UserVerification userVerification);
        Task UpdateUserVerificationAsync(UserVerification userVerification);
    }
}
