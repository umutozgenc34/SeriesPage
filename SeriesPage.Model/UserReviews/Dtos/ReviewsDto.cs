namespace SeriesPage.Model.UserReviews.Dtos;

public sealed record ReviewsDto
{
    public int Id { get; init; }
    public string NickName { get; init; }
    public string Email { get; init; }
    public string Title { get; init; } 
    public string Content { get; init; } 
    public float Rating { get; init; }
}
