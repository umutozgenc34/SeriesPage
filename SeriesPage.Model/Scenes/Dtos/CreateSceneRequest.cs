using Microsoft.AspNetCore.Http;

namespace SeriesPage.Model.Scenes.Dtos;

public sealed record CreateSceneRequest(string? Description,IFormFile VideoUrl);

