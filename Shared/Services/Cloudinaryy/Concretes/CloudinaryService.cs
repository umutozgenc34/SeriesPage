﻿using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Shared.Services.Cloudinaryy.Abstracts;
using Shared.Services.Cloudinaryy.Settings;

namespace Shared.Services.Cloudinaryy.Concretes;

public sealed class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;
    private readonly Account _account;
    private readonly CloudinarySettings _cloudinarySettings;
    public CloudinaryService(IOptions<CloudinarySettings> cloudOptions)
    {
        _cloudinarySettings = cloudOptions.Value;
        _account = new Account(_cloudinarySettings.CloudName, _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret);
        _cloudinary = new CloudinaryDotNet.Cloudinary(_account);
    }
    public async Task<string> UploadImage(IFormFile formFile, string imageDirectory)
    {
        var imageUploadResult = new ImageUploadResult();
        if (formFile.Length > 0)
        {
            using var stream = formFile.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(formFile.Name, stream),
                Folder = imageDirectory
            };
            imageUploadResult = await _cloudinary.UploadAsync(uploadParams);
            string url = _cloudinary.Api.UrlImgUp.BuildUrl(imageUploadResult.PublicId);
            return url;
        }
        return string.Empty;
    }

    public async Task<string> UploadVideo(IFormFile formFile, string videoDirectory)
    {
        if (formFile.Length > 0)
        {
            using var stream = formFile.OpenReadStream();

            var uploadParams = new VideoUploadParams()
            {
                File = new FileDescription(formFile.FileName, stream),
                Folder = videoDirectory
            };

            var videoUploadResult = await _cloudinary.UploadAsync(uploadParams);

            string videoUrl = _cloudinary.Api.UrlVideoUp.BuildUrl(videoUploadResult.PublicId);

            return videoUrl;
        }

        return string.Empty;
    }
}