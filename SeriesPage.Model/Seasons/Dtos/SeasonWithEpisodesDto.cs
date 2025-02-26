using SeriesPage.Model.Episodes.Dtos;

namespace SeriesPage.Model.Seasons.Dtos;

public sealed record SeasonWithEpisodesDto
{
    public int Id { get; init; }
    public int SeasonNumber { get; init; }
    public List<EpisodeDto> Episodes { get; init; }
}
