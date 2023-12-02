using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using LUSCMaintenance.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LUSCMaintenance.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        //public PhotoService(IOptions<CloudinarySettings> config)
        //{
        //    var account = new Account
        //    {
        //        Cloud = config.Value.CloudName,
        //        ApiKey = config.Value.ApiKey,
        //        ApiSecret = config.Value.ApiSecret
        //    };

        //    _cloudinary = new Cloudinary(account);
        //}

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
            {
                Cloud = "diajdiurh",
                ApiKey = "245272367391712",
                ApiSecret = "_yGJIVp_KnqjekgXytEqpdlSE_A"
            };

            _cloudinary = new Cloudinary(acc);


        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file == null || file.Length == 0)
            {
                return uploadResult;
            }

            // Resize the image to 300KB
            var maxSizeInBytes = 300 * 1024; // 300KB
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;

                // Resize the image to 300KB
                var resizedImageStream = ResizeImage(stream, maxSizeInBytes);

                // Upload the resized image to Cloudinary
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, resizedImageStream),
                    PublicId = $"maintenance_problem_{Guid.NewGuid()}"
                    // Add other Cloudinary upload parameters as needed
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }

        private Stream ResizeImage(Stream sourceStream, int targetSizeInBytes)
        {
            var image = Image.Load(sourceStream);

            var quality = 80; // Adjust quality as needed
            var targetFormat = new JpegEncoder { Quality = quality };
            var resultStream = new MemoryStream();

            do
            {
                image.Save(resultStream, targetFormat);
                quality -= 5;
            }
            while (resultStream.Length > targetSizeInBytes && quality > 0);

            resultStream.Position = 0;
            return resultStream;
        }
    }
}
