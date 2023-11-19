using LUSCMaintenance.Models;

namespace LUSCMaintenance.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string webMail);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<UserVerification> GetUserVerificationAsync(string userId);
        Task CreateUserVerificationAsync(UserVerification userVerification);
        Task UpdateUserVerificationAsync(UserVerification userVerification);
    }
}
