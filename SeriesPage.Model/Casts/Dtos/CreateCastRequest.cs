using Microsoft.AspNetCore.Http;

namespace SeriesPage.Model.Casts.Dtos;

public sealed record CreateCastRequest(string RealName,string NameInTheSeries,IFormFile? ImageUrl);

