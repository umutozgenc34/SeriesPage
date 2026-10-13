using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Shared.Exceptions;
using Shared.Services.Cloudinaryy.Abstracts;
using Shared.Services.Cloudinaryy.Settings;

namespace Shared.Services.Cloudinaryy.Concretes;

public sealed class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IOptions<CloudinarySettings> cloudOptions)
    {
        var settings = cloudOptions.Value;
        var account = new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret);
        _cloudinary = new Cloudinary(account) { Api = { Secure = true } };
    }

    public async Task<string> UploadImage(IFormFile formFile, string imageDirectory)
    {
        if (formFile.Length == 0)
            return string.Empty;

        await using var stream = formFile.OpenReadStream();
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(formFile.FileName, stream),
            Folder = imageDirectory
        };

        var result = await _cloudinary.UploadAsync(uploadParams);
        EnsureSuccess(result);

        return result.SecureUrl.ToString();
    }

    public async Task<string> UploadVideo(IFormFile formFile, string videoDirectory)
    {
        if (formFile.Length == 0)
            return string.Empty;

        await using var stream = formFile.OpenReadStream();
        var uploadParams = new VideoUploadParams()
        {
            File = new FileDescription(formFile.FileName, stream),
            Folder = videoDirectory
        };

        var result = await _cloudinary.UploadAsync(uploadParams);
        EnsureSuccess(result);

        return result.SecureUrl.ToString();
    }

    private static void EnsureSuccess(BaseResult result)
    {
        if (result.Error is not null)
            throw new BusinessException($"File upload failed: {result.Error.Message}");
    }
}
