using Shared.Repositories;

namespace SeriesPage.Model.Summaries.Entities;
public sealed class Summary : BaseEntity<int>
{
    public string Text { get; set; } = default!;
}
