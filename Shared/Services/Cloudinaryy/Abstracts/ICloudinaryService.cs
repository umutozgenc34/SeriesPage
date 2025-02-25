using Microsoft.AspNetCore.Http;

namespace Shared.Services.Cloudinaryy.Abstracts;

public interface ICloudinaryService
{
    Task<string> UploadImage(IFormFile formFile, string imageDirectory);
}
