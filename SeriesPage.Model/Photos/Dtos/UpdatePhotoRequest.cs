using Microsoft.AspNetCore.Http;

namespace SeriesPage.Model.Photos.Dtos;

public sealed record UpdatePhotoRequest(int Id,IFormFile ImageUrl);
