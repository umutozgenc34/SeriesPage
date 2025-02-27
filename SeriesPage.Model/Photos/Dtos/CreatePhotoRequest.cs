using Microsoft.AspNetCore.Http;

namespace SeriesPage.Model.Photos.Dtos;

public sealed record CreatePhotoRequest(IFormFile ImageUrl);


