using Shared.Repositories;

namespace SeriesPage.Model.UserReviews.Entities;

public class Reviews : BaseEntity<int>
{
    public string NickName { get; set; } = default!;
    public string? Email { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public float Rating { get; set; }
}
