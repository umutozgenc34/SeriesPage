using Microsoft.AspNetCore.Http;

namespace SeriesPage.Model.Episodes.Dtos;

public sealed record UpdateEpisodeRequest(int Id,string Name, int EpisodeNumber, IFormFile VideoUrl, int SeasonId);