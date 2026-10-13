namespace SeriesPage.Model.UserReviews.Dtos;

public sealed record ReviewsDto
{
    public int Id { get; init; }
    public string NickName { get; init; } = default!;
    public string Title { get; init; } = default!;
    public string Content { get; init; } = default!;
    public float Rating { get; init; }
}
