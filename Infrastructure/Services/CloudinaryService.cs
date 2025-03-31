using Application.Interfaces.Cloudinary;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;
    private readonly string _cloudName;
    private readonly string _apiKey;
    private readonly string _apiSecret;
    
    public CloudinaryService(IConfiguration config)
    {
        _cloudName = config["Cloudinary:CloudName"];
        _apiKey = config["Cloudinary:ApiKey"];
        _apiSecret = config["Cloudinary:ApiSecret"];

        var account = new Account(_cloudName, _apiKey, _apiSecret);
        _cloudinary = new Cloudinary(account);
    }
    public async Task<CloudinaryUploadResult> UploadImageAsync(string filePath)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(filePath)
        };
    
        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
    
        return new CloudinaryUploadResult
        {
            Url = uploadResult.SecureUrl.ToString(),
            PublicId = uploadResult.PublicId
        };
    }
    
    public async Task<bool> DeleteImageAsync(string publicId)
    {
        var deletionParams = new DeletionParams(publicId);
        var result = await _cloudinary.DestroyAsync(deletionParams);
        return result.Result == "ok";
    }
}
