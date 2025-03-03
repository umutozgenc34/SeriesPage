using Shared.Repositories;

namespace SeriesPage.Model.Awards.Entities;

public class Award : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public string WinnerName { get; set; } = default!;
    public string Category { get; set; } = default!;
    public int Year { get; set; }
}
