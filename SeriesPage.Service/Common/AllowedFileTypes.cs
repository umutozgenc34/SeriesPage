using Microsoft.AspNetCore.Http;

namespace SeriesPage.Service.Common;

public static class AllowedFileTypes
{
    public static readonly string[] Images = [".jpg", ".jpeg", ".png", ".gif", ".webp"];
    public static readonly string[] Videos = [".mp4", ".mov", ".webm", ".mkv", ".avi"];

    public static bool IsImage(IFormFile? file) => HasAllowedExtension(file, Images);
    public static bool IsVideo(IFormFile? file) => HasAllowedExtension(file, Videos);

    private static bool HasAllowedExtension(IFormFile? file, string[] extensions) =>
        file is null || extensions.Contains(Path.GetExtension(file.FileName).ToLowerInvariant());
}
