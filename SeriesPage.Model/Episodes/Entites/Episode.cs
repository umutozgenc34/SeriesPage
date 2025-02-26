using SeriesPage.Model.Seasons.Entities;
using Shared.Repositories;

namespace SeriesPage.Model.Episodes.Entites;

public class Episode : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public int EpisodeNumber { get; set; }
    public string VideoUrl { get; set; } = default!;
    public int SeasonId { get; set; }
    public Season Season { get; set; } = default!;
}