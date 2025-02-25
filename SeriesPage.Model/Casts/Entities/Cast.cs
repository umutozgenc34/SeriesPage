using Shared.Repositories;

namespace SeriesPage.Model.Casts.Entities;

public class Cast : BaseEntity<int>
{
    public string NameInTheSeries { get; set; } = default!;
    public string RealName { get; set; } = default!;
    public string? ImageUrl { get; set; }
}
