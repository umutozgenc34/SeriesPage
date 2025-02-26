using Shared.Repositories;

namespace SeriesPage.Model.Seasons.Entities;

public class Season : BaseEntity<int>
{
    public int SeasonNumber { get; set; }
}
