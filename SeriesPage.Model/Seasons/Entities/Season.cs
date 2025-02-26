using SeriesPage.Model.Episodes.Entites;
using Shared.Repositories;

namespace SeriesPage.Model.Seasons.Entities;

public class Season : BaseEntity<int>
{
    public int SeasonNumber { get; set; }
    public List<Episode> Episodes { get; set; } = new();
}
