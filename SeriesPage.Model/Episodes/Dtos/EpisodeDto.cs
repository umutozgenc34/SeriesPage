namespace SeriesPage.Model.Episodes.Dtos;

public sealed record EpisodeDto
{
    public int Id { get; init; }
    public string Name { get; init; } 
    public int EpisodeNumber { get; init; }
    public string VideoUrl { get; init; } 
    public int SeasonNumber { get; init; }
}
