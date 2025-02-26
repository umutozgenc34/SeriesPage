using Shared.Repositories;

namespace SeriesPage.Model.Scenes.Entities;

public class Scene : BaseEntity<int>
{
    public string? Description { get; set; }
    public string VideoUrl { get; set; } = default!;
}
