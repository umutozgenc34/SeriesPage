using SeriesPage.Model.Episodes.Entites;
using Shared.Repositories;
using System.Text.Json.Serialization;

namespace SeriesPage.Model.Seasons.Entities;

public class Season : BaseEntity<int>
{
    public int SeasonNumber { get; set; }
    [JsonIgnore]
    public List<Episode> Episodes { get; set; } = new();
}
