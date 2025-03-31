namespace Application.Interfaces.Cloudinary;

public interface ICloudinaryService
{
    Task<CloudinaryUploadResult> UploadImageAsync(string imagePath);
    Task<bool> DeleteImageAsync(string publicId);
}