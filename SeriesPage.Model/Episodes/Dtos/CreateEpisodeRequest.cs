using Microsoft.AspNetCore.Http;

namespace SeriesPage.Model.Episodes.Dtos;

public sealed record CreateEpisodeRequest(string Name,int EpisodeNumber,IFormFile VideoUrl,int SeasonId);

