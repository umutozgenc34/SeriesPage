using Microsoft.AspNetCore.Http;

namespace SeriesPage.Model.Casts.Dtos;

public sealed record UpdateCastRequest(int Id,string RealName, string NameInTheSeries, IFormFile? ImageUrl);

