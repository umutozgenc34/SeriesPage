using Microsoft.AspNetCore.Http;

namespace SeriesPage.Model.Scenes.Dtos;

public sealed record UpdateSceneRequest(int Id,string? Description,IFormFile VideoUrl);


