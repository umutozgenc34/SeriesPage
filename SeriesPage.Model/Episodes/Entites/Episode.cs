using SeriesPage.Model.Seasons.Entities;
using Shared.Repositories;
using System.Text.Json.Serialization;

namespace SeriesPage.Model.Episodes.Entites;

public class Episode : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public int EpisodeNumber { get; set; }
    public string VideoUrl { get; set; } = default!;
    public int SeasonId { get; set; }
    [JsonIgnore]
    public Season Season { get; set; } = default!;
}