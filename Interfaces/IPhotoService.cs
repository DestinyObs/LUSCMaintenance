using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LUSCMaintenance.Services
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file, int maxSizeInBytes);

        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
    