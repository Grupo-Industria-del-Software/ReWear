using Application.DTOs.Cloudinary;

namespace Application.Interfaces.Cloudinary;

public interface ICloudinaryService
{
    Task<CloudinaryUploadResultDto> UploadImageAsync(string imagePath);
    Task<bool> DeleteImageAsync(string publicId);
}